import React, { useEffect, useState } from "react";
import { Input, Modal, Button, Form } from "antd";
import ProductObj from "../Entities/ProductObj";

interface PropsType {
    editingProduct: ProductObj | undefined;
    addProduct: (product: ProductObj) => void;
    updateProduct: (product: ProductObj) => void;
    createModalIsShow: boolean;
    showCreateModel: (value: boolean) => void;
}

const ProductCreate : React.FC<PropsType> = ({
    editingProduct: editingProduct,
    addProduct: addProduct,
    updateProduct: updateProduct,
    createModalIsShow, 
    showCreateModel
}) => {
    const [form] = Form.useForm(); //Создание экземпляра формы
    const [name, setName] = useState<string>(""); //Текущее значение названия компании
    const [price, setPrice] = useState<number>(0); //Текущее значение цены
    const [count, setCount] = useState<number>(0); //Текущее значение количества
    const [catalogString, setCatalogString] = useState<string>(""); //Текущее значение строки каталога
    const [isEdit, setIsEdit] = useState<boolean>(false); //Редактриуется ли текущая компания

    useEffect(() => {

        if (editingProduct !== undefined)
        {
            form.setFieldsValue({
                name: editingProduct.name
            });
            setName(editingProduct.name);
            setPrice(editingProduct.price);
            setCount(editingProduct.count);
            setCatalogString(editingProduct.catalogString);
            console.log(editingProduct.name)
            setIsEdit(true);
        }

        return () => {
            form.resetFields();
            setIsEdit(false);
        }
    }, [editingProduct, form]);

    const handleSubmit = (e: Event) => {
        const createProducts = async () => {
            const product : ProductObj = {
                name,
                price,
                count,
                catalogString
            }

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(product)
            };

            const response = await fetch(`http://localhost:5075/api/Product`, requestOptions);
            return await response.json()
                .then((data) => {
                    console.log(data)
                    if (response.ok) {
                        addProduct(data);
                        form.resetFields();
                    }
                },
                (error) => console.log(error)
                );
        };

        const editProducts = async (id: number | undefined) => {
            const product: ProductObj = {
                id,
                name,
                price,
                count,
                catalogString
            }
    
            const requestOptions = {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(product)
            };
    
            const response = await fetch(`http://localhost:5075/api/Product/${id}`, requestOptions);
            await response.json()
                .then(
                    (data) => {
                        if (response.ok) {
                            console.log(data)
                            updateProduct(data);
                            setIsEdit(false);
                            form.resetFields();
                        }
                    },
                    (error) => console.log(error)
                );
        };

        if (isEdit)
        {
            console.log(editingProduct);
            editProducts(editingProduct?.id);
        }
        else createProducts();
    };

    return (
        <Modal open={createModalIsShow}
            title="Форма компании"
            onCancel={() => showCreateModel(false)}
            footer={[
                <Button
                    key="submitButton"
                    form="productForm"
                    type="primary"
                    htmlType="submit"
                    onClick={() => showCreateModel(false)}>
                    Save
                </Button>,
                <Button key="closeButton" onClick={() => showCreateModel(false)} danger>
                    Close
                </Button>
            ]}>
            <Form id="productForm" onFinish={handleSubmit} form={form}>
                <Form.Item name="name" label="Название компании" hasFeedback rules={[
                    {
                        required: true,
                        type: "string",
                        message: "Введите название компании"
                    }
                ]}>
                    <Input
                        key="nameProduct"
                        type="text"
                        name="nameProduct"
                        placeholder=""
                        value={name}
                        onChange={(e) => setName(e.target.value)} />
                </Form.Item>
            </Form>
            <Form id="productForm" onFinish={handleSubmit} form={form}>
                <Form.Item name="price" label="Цена, руб." hasFeedback rules={[
                    {
                        required: true,
                        type: "string",
                        message: "Введите название компании"
                    }
                ]}>
                </Form.Item>
            </Form>
        </Modal>
    );
};
export default ProductCreate;
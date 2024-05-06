import React, { useState, useEffect } from "react";
import { Button, Table } from "antd";
import type { TableProps } from "antd";
import ProductObj from "../Entities/ProductObj";
import ProductCreate from "../Products/ProductCreate";

interface PropsType { }

const Product : React.FC<PropsType> = () => {

    const [products, setProducts] = useState<Array<ProductObj>>([]); //Хранение состояния продукта
    const [createModalIsShow, showCreateModel] = useState<boolean>(false); //Храниение состояния модального окна для создания продукта
    const [editingProduct, setEditingProduct] = useState<ProductObj>(); //Хранение компании, которую редактируют

    const removeProduct = (removeId: number | undefined) => setProducts(products.filter(({ id }) => id !== removeId));

    const updateProducts = (product : ProductObj) => {
        setProducts(
            products.map((e) => {
                if (e.id === product.id)
                    return product;
                return e;
            })
        )
    };

    const addProduct = (product : ProductObj) => setProducts([...products, product]);

    useEffect(() => {
        const getProducts = async () => {

            const requestOptions: RequestInit = {
                method: 'GET'
            };

            await fetch(`http://localhost:5075/api/Product`, requestOptions)
                .then(response => response.json())
                .then(
                    (data) => {
                        console.log(data);
                        setProducts(data);
                    },
                    (error) => console.log(error)
                );
        };
        getProducts();
    }, [createModalIsShow]);

    const deleteProduct = async (id: number | undefined) => {
        const requestOptions: RequestInit = {
            method: 'DELETE'
        }

        return await fetch(`http://localhost:5075/api/Product/${id}`, requestOptions)
            .then((response) => {
                if (response.ok) {
                    removeProduct(id);
                    console.log(id);
                }
            },
                (error) => console.log(error)
            )
    };

    const editProduct = (obj : ProductObj) => {
        setEditingProduct(obj);
        console.log(obj)
        showCreateModel(true);
    };

    const columns : TableProps<ProductObj>["columns"] = [
        {
            title: "Название продукта",
            dataIndex: "name",
            key: "name",
        },
        {
            key: "Delete",
            render: (row : ProductObj) => (
                <Button key="deleteButton"
                        type="primary"
                        onClick={() => deleteProduct(row.id)}
                        danger>
                            Удалить
                </Button>
            ),
        },
        {
            key: "Edit",
            render: (row : ProductObj) => (
                <Button key="editButton"
                        type="primary"
                        onClick={() => editProduct(row)}>
                            Изменить
                </Button>
            ),
        }
    ];

    return (
        <React.Fragment>
            <ProductCreate
                editingProduct={editingProduct}
                addProduct={addProduct}
                updateProduct={updateProducts}
                createModalIsShow={createModalIsShow}
                showCreateModel={showCreateModel}
            />
            <Button onClick={(e) => showCreateModel(true)}>Добавить продукт</Button>
            <Table
                key="CompaniesTable"
                dataSource={products}
                columns={columns}
                pagination={{pageSize: 15}}
                scroll={{y: 1000}}
                bordered
            />
        </React.Fragment>
    )
};
export default Product;
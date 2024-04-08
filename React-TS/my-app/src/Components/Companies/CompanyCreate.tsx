import React, { useEffect, useState } from "react";
import { Input, Modal, Button, Form } from "antd";
import CompanyObj from "../Entities/CompanyObj";

interface PropsType {
    editingCompany: CompanyObj | undefined;
    addCompany: (company: CompanyObj) => void;
    updateCompany: (company: CompanyObj) => void;
    createModalIsShow: boolean;
    showCreateModel: (value: boolean) => void;
}

const CompanyCreate : React.FC<PropsType> = ({
    editingCompany,
    addCompany,
    updateCompany,
    createModalIsShow, 
    showCreateModel
}) => {
    const [form] = Form.useForm(); //Создание экземпляра формы
    const [name, setName] = useState<string>(""); //Текущее значение названия компании
    const [isEdit, setIsEdit] = useState<boolean>(false); //Редактриуется ли текущая компания

    useEffect(() => {

        if (editingCompany !== undefined)
        {
            form.setFieldsValue({
                name: editingCompany.name
            });
            setName(editingCompany.name);
            console.log(editingCompany.name)
            setIsEdit(true);
        }

        return () => {
            form.resetFields();
            setIsEdit(false);
        }
    }, [editingCompany, form]);

    const handleSubmit = (e: Event) => {
        const createCompanies = async () => {
            const company : CompanyObj = {
                name
            }

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(company)
            };

            const response = await fetch(`http://localhost:5075/api/Companies`, requestOptions);
            return await response.json()
                .then((data) => {
                    console.log(data)
                    if (response.ok) {
                        addCompany(data);
                        form.resetFields();
                    }
                },
                (error) => console.log(error)
                );
        };

        const editCompanies = async (id: number | undefined) => {
            const company: CompanyObj = {
                id,
                name,
            }
    
            const requestOptions = {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(company)
            };
    
            const response = await fetch(`http://localhost:5075/api/Companies/${id}`, requestOptions);
            await response.json()
                .then(
                    (data) => {
                        if (response.ok) {
                            console.log(data)
                            updateCompany(data);
                            setIsEdit(false);
                            form.resetFields();
                        }
                    },
                    (error) => console.log(error)
                );
        };

        if (isEdit)
        {
            console.log(editingCompany);
            editCompanies(editingCompany?.id);
        }
        else createCompanies();
    };

    return (
        <Modal open={createModalIsShow}
            title="Форма компании"
            onCancel={() => showCreateModel(false)}
            footer={[
                <Button
                    key="submitButton"
                    form="companyForm"
                    type="primary"
                    htmlType="submit"
                    onClick={() => showCreateModel(false)}>
                    Save
                </Button>,
                <Button key="closeButton" onClick={() => showCreateModel(false)} danger>
                    Close
                </Button>
            ]}>
            <Form id="companyForm" onFinish={handleSubmit} form={form}>
                <Form.Item name="name" label="Название компании" hasFeedback rules={[
                    {
                        required: true,
                        type: "string",
                        message: "Введите название компании"
                    }
                ]}>
                    <Input
                        key="nameCompany"
                        type="text"
                        name="nameCompany"
                        placeholder=""
                        value={name}
                        onChange={(e) => setName(e.target.value)} />
                </Form.Item>
            </Form>
        </Modal>
    );
};
export default CompanyCreate;
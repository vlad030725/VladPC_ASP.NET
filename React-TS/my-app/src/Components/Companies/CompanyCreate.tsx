import React, { useEffect, useState } from "react";
import { Input, Modal, Button, Form, Select, } from "antd";
import CompanyObj from "../Entities/CompanyObj";

interface PropsType {
    addCompany: (worker: CompanyObj) => void;
    createModalIsShow: boolean;
    showCreateModel: (value: boolean) => void;
}

const TaskCreate : React.FC<PropsType> = ({
    addCompany: addTask,
    createModalIsShow, 
    showCreateModel
}) => {
    const [form] = Form.useForm();
    const [name, setName] = useState<string>("");

    useEffect(() => {

        const getProjects = async () => {

            const requestOptions: RequestInit = {
                method: 'GET'
            };

            await fetch(`http://localhost:7118/api/Projects`, requestOptions)
                .then(response => response.json())
                .then(
                    (data) => {
                        console.log("--------");
                        console.log(data);
                        //setProjects(data);
                    },
                    (error) => console.log(error)
                );
        };

        getProjects();

        return () => {
            form.resetFields();
        }
    }, [form]);

    const handleSubmit = (e: Event) => {
        const createTasks = async () => {
            const task : CompanyObj = {
                name
            }

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(task)
            };

            const response = await fetch(`http://localhost:7118/api/Companies`, requestOptions);
            return await response.json()
                .then((data) => {
                    console.log(data)
                    if (response.ok) {
                        addTask(data);
                        form.resetFields();
                    }
                },
                (error) => console.log(error)
                );
        };
        createTasks();
    };

    return (
        <Modal open={createModalIsShow}
            title="Форма задания"
            onCancel={() => showCreateModel(false)}
            footer={[
                <Button
                    key="submitButton"
                    form="projectForm"
                    type="primary"
                    htmlType="submit"
                    onClick={() => showCreateModel(false)}>
                    Save
                </Button>,
                <Button key="closeButton" onClick={() => showCreateModel(false)} danger>
                    Close
                </Button>
            ]}>
            <Form id="projectForm" onFinish={handleSubmit} form={form}>
                <Form.Item name="name" label="Название задания" hasFeedback rules={[
                    {
                        required: true,
                        type: "string",
                        message: "Введите название задания"
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
export default TaskCreate;
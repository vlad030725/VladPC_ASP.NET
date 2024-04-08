import React, { useState, useEffect } from "react";
import { Button, Table } from "antd";
import type { TableProps } from "antd";
import TypeProductObj from "../Entities/TypeProductObj";
import TypeProductCreate from "../TypesProduct/TypeProductCreate";

interface PropsType { }

const TypeProduct : React.FC<PropsType> = () => {

    const [typesProduct, setTypesProduct] = useState<Array<TypeProductObj>>([]); //Хранение состояния компаний
    const [createModalIsShow, showCreateModel] = useState<boolean>(false); //Храниение состояния модального окна для создания компании
    const [editingTypeProduct, setEditingTypeProduct] = useState<TypeProductObj>(); //Хранение компании, которую редактируют

    const removeTypeProduct = (removeId: number | undefined) => setTypesProduct(typesProduct.filter(({ id }) => id !== removeId));

    const updateTypesProduct = (typeProduct : TypeProductObj) => {
        setTypesProduct(
            typesProduct.map((e) => {
                if (e.id === typeProduct.id)
                    return typeProduct;
                return e;
            })
        )
    };

    const addTypeProduct = (typeProduct : TypeProductObj) => setTypesProduct([...typesProduct, typeProduct]);

    useEffect(() => {
        const getTypesProduct = async () => {

            const requestOptions: RequestInit = {
                method: 'GET'
            };

            await fetch(`http://localhost:5075/api/TypesProduct`, requestOptions)
                .then(response => response.json())
                .then(
                    (data) => {
                        console.log(data);
                        setTypesProduct(data);
                    },
                    (error) => console.log(error)
                );
        };
        getTypesProduct();
    }, [createModalIsShow]);

    const deleteTypesProduct = async (id: number | undefined) => {
        const requestOptions: RequestInit = {
            method: 'DELETE'
        }

        return await fetch(`http://localhost:5075/api/TypesProduct/${id}`, requestOptions)
            .then((response) => {
                if (response.ok) {
                    removeTypeProduct(id);
                    console.log(id);
                }
            },
                (error) => console.log(error)
            )
    };

    const editTypesProduct = (obj : TypeProductObj) => {
        setEditingTypeProduct(obj);
        console.log(obj)
        showCreateModel(true);
    };

    const columns : TableProps<TypeProductObj>["columns"] = [
        {
            title: "Название типа продукта",
            dataIndex: "name",
            key: "name",
        },
        {
            key: "Delete",
            render: (row : TypeProductObj) => (
                <Button key="deleteButton"
                        type="primary"
                        onClick={() => deleteTypesProduct(row.id)}
                        danger>
                            Удалить
                </Button>
            ),
        },
        {
            key: "Edit",
            render: (row : TypeProductObj) => (
                <Button key="editButton"
                        type="primary"
                        onClick={() => editTypesProduct(row)}>
                            Изменить
                </Button>
            ),
        }
    ];

    return (
        <React.Fragment>
            <TypeProductCreate
                editingTypeProduct={editingTypeProduct}
                addTypeProduct={addTypeProduct}
                updateTypeProduct={updateTypesProduct}
                createModalIsShow={createModalIsShow}
                showCreateModel={showCreateModel}
            />
            <Button onClick={(e) => showCreateModel(true)}>Добавить тип продукта</Button>
            <Table
                key="TypesProductTable"
                dataSource={typesProduct}
                columns={columns}
                pagination={{pageSize: 15}}
                scroll={{y: 1000}}
                bordered
            />
        </React.Fragment>
    )
};
export default TypeProduct;
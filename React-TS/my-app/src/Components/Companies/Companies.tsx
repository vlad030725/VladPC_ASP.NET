import React, { useState, useEffect } from "react";
import { Button, Table } from "antd";
import type { TableProps } from "antd";
import CompanyObj from "../Entities/CompanyObj";
import CompanyCreate from "../Companies/CompanyCreate";

interface PropsType { }

const Company : React.FC<PropsType> = () => {

    const [companies, setCompanies] = useState<Array<CompanyObj>>([]);
    const [createModalIsShow, showCreateModel] = useState<boolean>(false);
    const [editingCompany, setEditingCompany] = useState<CompanyObj>();

    const removeCompany = (removeId: number | undefined) => setCompanies(companies.filter(({ id }) => id !== removeId));

    const updateCompanies = (company : CompanyObj) => {
        setCompanies(
            companies.map((e) => {
                if (e.id === company.id)
                    return company;
                return e;
            })
        )
    };

    const addCompany = (company : CompanyObj) => setCompanies([...companies, company]);

    useEffect(() => {
        const getCompanies = async () => {

            const requestOptions: RequestInit = {
                method: 'GET'
            };

            await fetch(`http://localhost:5075/api/Companies`, requestOptions)
                .then(response => response.json())
                .then(
                    (data) => {
                        console.log(data);
                        setCompanies(data);
                    },
                    (error) => console.log(error)
                );
        };
        getCompanies();
    }, [createModalIsShow]);

    const deleteCompany = async (id: number | undefined) => {
        const requestOptions: RequestInit = {
            method: 'DELETE'
        }

        return await fetch(`http://localhost:5075/api/Companies/${id}`, requestOptions)
            .then((response) => {
                if (response.ok) {
                    removeCompany(id);
                    console.log(id);
                }
            },
                (error) => console.log(error)
            )
    };

    const editCompany = (obj : CompanyObj) => {
        setEditingCompany(obj);
        console.log(obj)
        showCreateModel(true);
    };

    const columns : TableProps<CompanyObj>["columns"] = [
        {
            title: "Название компании",
            dataIndex: "name",
            key: "name",
        },
        {
            key: "Delete",
            render: (row : CompanyObj) => (
                <Button key="deleteButton"
                        type="primary"
                        onClick={() => deleteCompany(row.id)}
                        danger>
                            Удалить
                </Button>
            ),
        },
        {
            key: "Edit",
            render: (row : CompanyObj) => (
                <Button key="editButton"
                        type="primary"
                        onClick={() => editCompany(row)}>
                            Изменить
                </Button>
            ),
        }
    ];

    return (
        <React.Fragment>
            <CompanyCreate
                editingCompany={editingCompany}
                addCompany={addCompany}
                updateCompany={updateCompanies}
                createModalIsShow={createModalIsShow}
                showCreateModel={showCreateModel}
            />
            <Button onClick={(e) => showCreateModel(true)}>Добавить компанию</Button>
            <Table
                key="CompaniesTable"
                dataSource={companies}
                columns={columns}
                pagination={{pageSize: 15}}
                scroll={{y: 1000}}
                bordered
            />
        </React.Fragment>
    )
};
export default Company;
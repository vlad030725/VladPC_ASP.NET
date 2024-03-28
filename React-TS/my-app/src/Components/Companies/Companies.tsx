import React, { useState, useEffect } from "react";
import { Button, Table, Input } from "antd";
import type { TableProps } from "antd";
import { SearchOutlined } from "@ant-design/icons";
import { useLocation } from "react-router-dom";
import CompanyObj from "../Entities/CompanyObj";
import CompanyCreate from "../Companies/CompanyCreate";

interface PropsType { }

const Task : React.FC<PropsType> = () => {

    const [tasks, setCompanies] = useState<Array<CompanyObj>>([]);
    const [createModalIsShow, showCreateModel] = useState<boolean>(false);
    const [editingCompany, setEditingCompany] = useState<CompanyObj>();
    const location = useLocation();

    const removeCompany = (Id: number | undefined) => setCompanies(tasks.filter(({ id }) => id !== Id));

    const updateCompanies = (task : CompanyObj) => {
        setCompanies(
            tasks.map((e) => {
                if (e.id == task.id)
                    return task;
                return e;
            })
        )
    };

    const addCompany = (task : CompanyObj) => setCompanies([...tasks, task]);

    useEffect(() => {
        const getTasks = async () => {

            const requestOptions: RequestInit = {
                method: 'GET'
            };

            await fetch(`http://localhost:7118/api/Companies`, requestOptions)
                .then(response => response.json())
                .then(
                    (data) => {
                        console.log(data);
                        setCompanies(data);
                    },
                    (error) => console.log(error)
                );
        };
        getTasks();
    }, [createModalIsShow]);

    const deleteCompany = async (id: number | undefined) => {
        const requestOptions: RequestInit = {
            method: 'DELETE'
        }

        return await fetch(`http://localhost:7118/api/Companies/${id}`, requestOptions)
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
            filterDropdown: ({
                setSelectedKeys,
                selectedKeys,
                confirm,
                clearFilters,
            }) => (
                <React.Fragment>
                    <Input
                        autoFocus
                        placeholder="Введите название компании"
                        value={selectedKeys[0]}
                        onChange={(e) => setSelectedKeys(e.target.value ? [e.target.value] : [])}
                        onPressEnter={() => confirm()}
                        onBlur={() => confirm()}>
                    </Input>
                    <Button onClick={() => confirm()} type="primary" key="serchButton">
                        Поиск
                    </Button>
                    <Button 
                        onClick={() => {
                            clearFilters ? clearFilters() : setSelectedKeys([]);
                            confirm();
                        }}
                        type="primary"
                        danger
                        key="dropFilter">
                            Сброс фильтра
                </Button>
                </React.Fragment>
            ),
            filterIcon: () => <SearchOutlined />,
            onFilter: (value, record) =>
              record.name.toLowerCase().includes(value.toString().toLowerCase()),
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
                addCompany={addCompany}
                createModalIsShow={createModalIsShow}
                showCreateModel={showCreateModel}
            />
            <h3>{location.state.currentProject.name}</h3>
            <Button onClick={(e) => showCreateModel(true)}>Добавить компанию</Button>
            <Table
                key="CompaniesTable"
                dataSource={tasks}
                columns={columns}
                pagination={{pageSize: 15}}
                scroll={{y: 1000}}
                bordered
            />
        </React.Fragment>
    )
};
export default Task;
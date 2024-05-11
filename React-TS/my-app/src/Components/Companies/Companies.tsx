import React, { useState, useEffect } from "react";
import { Button, Table } from "antd";
import type { TableProps } from "antd";
import CompanyObj from "../Entities/CompanyObj";
import CompanyCreate from "../Companies/CompanyCreate";
import axios from "axios";

interface PropsType {}

const Company: React.FC<PropsType> = () => {
  const [companies, setCompanies] = useState<Array<CompanyObj>>([]); //Хранение состояния компаний
  const [createModalIsShow, showCreateModel] = useState<boolean>(false); //Храниение состояния модального окна для создания компании
  const [editingCompany, setEditingCompany] = useState<CompanyObj>(); //Хранение компании, которую редактируют

  const removeCompany = (removeId: number | undefined) =>
    setCompanies(companies.filter(({ id }) => id !== removeId));

  const updateCompanies = (company: CompanyObj) => {
    setCompanies(
      companies.map((e) => {
        if (e.id === company.id) return company;
        return e;
      })
    );
  };

  const addCompany = (company: CompanyObj) =>
    setCompanies([...companies, company]);

  useEffect(() => {
    const getCompanies = async () => {
      try {
        const response = await axios.get(
          "http://localhost:5075/api/Companies",
          { withCredentials: true }
        );
        console.log(response.data);
        setCompanies(response.data);
      } catch (error) {
        console.error("Ошибка при получении компаний:", error);
      }
    };
    getCompanies();
  }, [createModalIsShow]);

  const deleteCompany = async (id: number | undefined) => {
    try {
      const response = await axios.delete(`http://localhost:5075/api/Companies/${id}`,
      { withCredentials: true });
      if (response.status === 200) {
        removeCompany(id);
        console.log(id);
      }
    } catch (error) {
      console.error('Ошибка при удалении компании:', error);
    }
  };

  const editCompany = (obj: CompanyObj) => {
    setEditingCompany(obj);
    console.log(obj);
    showCreateModel(true);
  };

  const columns: TableProps<CompanyObj>["columns"] = [
    {
      title: "Название компании",
      dataIndex: "name",
      key: "name",
    },
    {
      key: "Delete",
      render: (row: CompanyObj) => (
        <Button
          key="deleteButton"
          type="primary"
          onClick={() => deleteCompany(row.id)}
          danger
        >
          Удалить
        </Button>
      ),
    },
    {
      key: "Edit",
      render: (row: CompanyObj) => (
        <Button
          key="editButton"
          type="primary"
          onClick={() => editCompany(row)}
        >
          Изменить
        </Button>
      ),
    },
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
        pagination={{ pageSize: 15 }}
        scroll={{ y: 1000 }}
        bordered
      />
    </React.Fragment>
  );
};
export default Company;

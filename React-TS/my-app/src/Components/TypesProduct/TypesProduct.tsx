import React, { useState, useEffect } from "react";
import { Button, Table } from "antd";
import type { TableProps } from "antd";
import TypeProductObj from "../Entities/TypeProductObj";
import TypeProductCreate from "../TypesProduct/TypeProductCreate";
import axios from "axios";

interface PropsType {}

const TypeProduct: React.FC<PropsType> = () => {
  const [typesProduct, setTypesProduct] = useState<Array<TypeProductObj>>([]); //Хранение состояния компаний
  const [createModalIsShow, showCreateModel] = useState<boolean>(false); //Храниение состояния модального окна для создания компании
  const [editingTypeProduct, setEditingTypeProduct] =
    useState<TypeProductObj>(); //Хранение компании, которую редактируют

  const removeTypeProduct = (removeId: number | undefined) =>
    setTypesProduct(typesProduct.filter(({ id }) => id !== removeId));

  const updateTypesProduct = (typeProduct: TypeProductObj) => {
    setTypesProduct(
      typesProduct.map((e) => {
        if (e.id === typeProduct.id) return typeProduct;
        return e;
      })
    );
  };

  const addTypeProduct = (typeProduct: TypeProductObj) =>
    setTypesProduct([...typesProduct, typeProduct]);

  useEffect(() => {
    const getTypesProduct = async () => {
      try {
        const response = await axios.get(
          "http://localhost:5075/api/TypeProduct",
          { withCredentials: true }
        );
        console.log(response.data);
        setTypesProduct(response.data);
      } catch (error) {
        console.error("Ошибка при получении типов продуктов:", error);
      }
    };
    getTypesProduct();
  }, [createModalIsShow]);

  const deleteTypesProduct = async (id: number | undefined) => {
    try {
      const response = await axios.delete(
        `http://localhost:5075/api/TypeProduct/${id}`,
        { withCredentials: true }
      );
      if (response.status === 200) {
        removeTypeProduct(id);
        console.log(id);
      }
    } catch (error) {
      console.error("Ошибка при удалении типа продукта:", error);
    }
  };

  const editTypesProduct = (obj: TypeProductObj) => {
    setEditingTypeProduct(obj);
    console.log(obj);
    showCreateModel(true);
  };

  const columns: TableProps<TypeProductObj>["columns"] = [
    {
      title: "Название типа продукта",
      dataIndex: "name",
      key: "name",
    },
    {
      key: "Delete",
      render: (row: TypeProductObj) => (
        <Button
          key="deleteButton"
          type="primary"
          onClick={() => deleteTypesProduct(row.id)}
          danger
        >
          Удалить
        </Button>
      ),
    },
    {
      key: "Edit",
      render: (row: TypeProductObj) => (
        <Button
          key="editButton"
          type="primary"
          onClick={() => editTypesProduct(row)}
        >
          Изменить
        </Button>
      ),
    },
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
      <Button onClick={(e) => showCreateModel(true)}>
        Добавить тип продукта
      </Button>
      <Table
        key="TypesProductTable"
        dataSource={typesProduct}
        columns={columns}
        pagination={{ pageSize: 15 }}
        scroll={{ y: 1000 }}
        bordered
      />
    </React.Fragment>
  );
};
export default TypeProduct;

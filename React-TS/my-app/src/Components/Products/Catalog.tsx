import React, { useState, useEffect } from "react";
import { Button, Table, notification } from "antd";
import type { TableProps } from "antd";
import ProductObj from "../Entities/ProductObj";
import UserObj from "../Entities/UserObj";
import CustomRowObj from "../Entities/CustomRowObj";
import { useNavigate } from "react-router-dom";
import axios from 'axios';

interface PropsType {
  user: UserObj | null;
}

const Product: React.FC<PropsType> = ({ user }) => {
  const [products, setProducts] = useState<Array<ProductObj>>([]); //Хранение состояния продукта
  const navigate = useNavigate();

  useEffect(() => {
    const getProducts = async () => {
      console.log(user);

      const requestOptions: RequestInit = {
        method: "GET",
      };

      await fetch(`http://localhost:5075/api/Product`, requestOptions)
        .then((response) => response.json())
        .then(
          (data) => {
            console.log(data);
            setProducts(data);
          },
          (error) => console.log(error)
        );
    };
    getProducts();
  }, []);

  const AddCustomRow = async (idProduct: number) => {
    console.log("idProduct:", idProduct);
    console.log("Попытка добавить в корзину", user);

    const customRow: CustomRowObj = {
      idProduct: idProduct,
      idCustom: Number(user?.id),
      price: 0,
      count: 0,
    };

    console.log(customRow);

    const requestOptions = {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Credentials": "true",
      },
      body: JSON.stringify(customRow),
    };

    const response = await fetch(
      `http://localhost:5075/api/CustomRows`,
      requestOptions
    );

    return await response.json().then(
      (data) => {
        console.log(data);
        if (response.ok) {
          notification.success({
            message: "Товар добавлен в корзину",
            placement: "topRight",
            duration: 2,
          });
        } else if (response.status === 401) {
          navigate("/login");
        }
      },
      (error) => console.log(error)
    );
  };

  const columns: TableProps<ProductObj>["columns"] = [
    {
      title: "Название продукта",
      dataIndex: "name",
      key: "name",
      width: "20%",
    },
    {
      title: "Характеристики",
      dataIndex: "catalogString",
      key: "catalogString",
    },
    {
      title: "Цена, руб.",
      dataIndex: "price",
      key: "price",
      width: "10%",
    },
    {
      title: "В наличии",
      dataIndex: "count",
      key: "count",
      width: "6%",
    },
    {
      key: "Delete",
      width: "15%",
      render: (row: ProductObj) =>  {
        if (row.count > 0) {
          return (
            <Button
              key="deleteButton"
              type="primary"
              onClick={() =>
                row.id !== undefined && row.id !== null && row.id !== 0
                  ? AddCustomRow(row.id as number)
                  : console.error("row.id is undefined or null")
              }
            >
              Добавить в корзину
            </Button>
          );
        } else {
          return (
            <Button disabled key="noStockButton">
              Нет в наличии
            </Button>
          );
        }
      },
    },
  ];

  return (
    <React.Fragment>
      <Table
        key="CatalogTable"
        dataSource={products}
        columns={columns}
        pagination={{ pageSize: 15 }}
        scroll={{ y: 1000 }}
        bordered
      />
    </React.Fragment>
  );
};
export default Product;

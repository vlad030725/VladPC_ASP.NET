import React, { useState, useEffect } from "react";
import { Button, Table, notification, Collapse, List } from "antd";
import type { TableProps } from "antd";
import UserObj from "../Entities/UserObj";
import CustomRowObj from "../Entities/CustomRowObj";
import CustomObj from "../Entities/CustomObj";
import { useNavigate } from "react-router-dom";
import { Label } from "reactstrap";

const { Panel } = Collapse;

interface PropsType {
  user: UserObj | null;
}

const Profile: React.FC<PropsType> = ({ user }) => {
  const [Cart, setProductsInCart] = useState<Array<CustomRowObj>>([]);
  const [historyCustoms, setHistoryCustoms] = useState<Array<CustomObj>>([]);
  const [historyCustomRows, setHistoryCustomRows] = useState<
    Array<Array<CustomRowObj>>
  >([[]]);
  const [customInCat, setCustomInCart] = useState<CustomObj | undefined>();
  const navigate = useNavigate();

  const removeCustomRow = (removeId: number | undefined) =>
    setProductsInCart(Cart.filter(({ id }) => id !== removeId));

  const updateCustomRows = (customRow: CustomRowObj) => {
    setProductsInCart(
      Cart.map((e) => {
        if (e.id === customRow.id) return customRow;
        return e;
      })
    );
  };

  const calculateTotal = (dataSource: CustomRowObj[]) => {
    return dataSource.reduce((total, item) => {
      return total + item.price * item.count;
    }, 0);
  };

  useEffect(() => {
    const getCart = async () => {
      console.log(user);

      const requestOptions: RequestInit = {
        method: "GET",
      };

      console.log(user);

      await fetch(
        `http://localhost:5075/api/Customs/user/${user?.id as number}`,
        requestOptions
      )
        .then((response) => response.json())
        .then(
          (data) => {
            console.log(data);
            setProductsInCart(data.customRows);
            setCustomInCart(data);
          },
          (error) => console.log(error)
        );
    };

    const getHistoryCustom = async () => {
      const requestOptions: RequestInit = {
        method: "GET",
      };

      await fetch(
        `http://localhost:5075/api/Customs/history/${user?.id}`,
        requestOptions
      )
        .then((response) => response.json())
        .then(
          (data) => {
            console.log(data);
            setHistoryCustoms(data);
            setHistoryCustomRows(data.map((custom: any) => custom.customRows));
            console.log(historyCustomRows);
          },
          (error) => console.log(error)
        );
    };

    if (user == null) {
      navigate("/login");
    } else {
      getHistoryCustom();
      getCart();
    }
  }, []);

  const deleteCustomRow = async (id: number | undefined) => {
    const requestOptions: RequestInit = {
      method: "DELETE",
    };

    console.log(id);

    return await fetch(
      `http://localhost:5075/api/CustomRows/${id}`,
      requestOptions
    ).then(
      (response) => {
        if (response.ok) {
          removeCustomRow(id);
          console.log(id);
        }
      },
      (error) => console.log(error)
    );
  };

  const editCustomRows = async (id: number, IsPlus: boolean) => {
    const customRow: CustomRowObj = Cart.find(
      (e) => e.id == id
    ) as CustomRowObj;
    const customRowRequest: CustomRowObj = {
      id: customRow.id,
      idProduct: customRow.idProduct,
      price: customRow.price,
      count: customRow.count,
      productName: customRow.productName,
    };

    console.log(customRowRequest);

    if (IsPlus) {
      customRowRequest.count++;
    } else {
      customRowRequest.count--;
    }

    const requestOptions = {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(customRowRequest),
    };

    const response = await fetch(
      `http://localhost:5075/api/CustomRows/${id}`,
      requestOptions
    );
    await response.json().then(
      (data) => {
        if (response.ok) {
          console.log(data);
          updateCustomRows(data);
        } else {
          if (IsPlus) {
            notification.error({
              message: "Выбрано максимально возможное количество товара",
              placement: "topRight",
              duration: 2,
            });
          } else {
            notification.error({
              message: "Выбрано минимально возможное количество товара",
              placement: "topRight",
              duration: 2,
            });
          }
        }
      },
      (error) => console.log(error)
    );
  };

  const makeCustom = async (id: number) => {
    const custom: CustomObj = {
      id,
      idUser: user?.id,
      idStatus: 3,
    };

    console.log(custom);

    const requestOptions = {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(custom),
    };

    const response = await fetch(
      `http://localhost:5075/api/Customs/${id}`,
      requestOptions
    );
    await response.json().then(
      (data) => {
        if (response.ok) {
          console.log(data);
          notification.success({
            message: "Заказ оформлен",
            placement: "topRight",
            duration: 2,
          });
          setProductsInCart([]);
          setCustomInCart(undefined);
        }
      },
      (error) => console.log(error)
    );
  };

  const columns: TableProps<CustomRowObj>["columns"] = [
    {
      title: "Название продукта",
      dataIndex: "productName",
      key: "name",
      width: "200px",
    },
    {
      title: "Цена, руб.",
      dataIndex: "price",
      key: "price",
      width: "100px",
    },
    {
      key: "minus",
      width: "70px",
      render: (row: CustomRowObj) => (
        <Button
          key="deleteButton"
          onClick={() =>
            row.id !== undefined && row.id !== null && row.id !== 0
              ? editCustomRows(row.id, false)
              : console.error("row.id is undefined or null")
          }
        >
          -
        </Button>
      ),
    },
    {
      title: "Кол-во, шт.",
      dataIndex: "count",
      key: "count",
      width: "90px",
    },
    {
      key: "plus",
      width: "70px",
      render: (row: CustomRowObj) => (
        <Button
          key="deleteButton"
          onClick={() =>
            row.id !== undefined && row.id !== null && row.id !== 0
              ? editCustomRows(row.id, true)
              : console.error("row.id is undefined or null")
          }
        >
          +
        </Button>
      ),
    },
    {
      key: "Delete",
      render: (row: CustomRowObj) => (
        <Button
          key="deleteButton"
          type="primary"
          onClick={() => deleteCustomRow(row.id)}
          danger
        >
          Удалить
        </Button>
      ),
    },
  ];

  const columnsHistory: TableProps<CustomRowObj>["columns"] = [
    {
      title: "Название продукта",
      dataIndex: "productName",
      key: "name",
      width: "200px",
    },
    {
      title: "Цена, руб.",
      dataIndex: "price",
      key: "price",
      width: "100px",
    },
    {
      title: "Кол-во, шт.",
      dataIndex: "count",
      key: "count",
    },
  ];

  return (
    <React.Fragment>
      <div style={{ margin: "10px" }}>
        <h4>Корзина</h4>
        <Table
          key="CartTable"
          dataSource={Cart}
          columns={columns}
          pagination={{ pageSize: 15 }}
          scroll={{ y: 1000 }}
          bordered
        />
        <h6>Итоговая сумма: {calculateTotal(Cart)}</h6>
        <br />
        <Button
          style={{ margin: "10px 10px 50px 30px" }}
          type="primary"
          onClick={() => makeCustom(customInCat?.id as number)}
        >
          Оформить заказ
        </Button>
        <h4>История заказов</h4>
        <List
          itemLayout="horizontal"
          dataSource={historyCustoms}
          renderItem={(custom, index) => (
            <List.Item>
              <List.Item.Meta
                title={`Заказ #${custom.id} - ${
                  custom.createdDate
                } - ${calculateTotal(historyCustomRows[index])} рублей`}
                description={
                  <Table
                    columns={columnsHistory}
                    dataSource={historyCustomRows[index]}
                    pagination={false}
                    rowKey="id"
                    size="small"
                  />
                }
              />
            </List.Item>
          )}
        />
      </div>
    </React.Fragment>
  );
};
export default Profile;

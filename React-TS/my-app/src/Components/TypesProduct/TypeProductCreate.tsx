import React, { useEffect, useState } from "react";
import { Input, Modal, Button, Form } from "antd";
import TypeProductObj from "../Entities/TypeProductObj";
import axios from "axios";

interface PropsType {
  editingTypeProduct: TypeProductObj | undefined;
  addTypeProduct: (typeProduct: TypeProductObj) => void;
  updateTypeProduct: (typeProduct: TypeProductObj) => void;
  createModalIsShow: boolean;
  showCreateModel: (value: boolean) => void;
}

const TypeProductCreate: React.FC<PropsType> = ({
  editingTypeProduct,
  addTypeProduct,
  updateTypeProduct,
  createModalIsShow,
  showCreateModel,
}) => {
  const [form] = Form.useForm(); //Создание экземпляра формы
  const [name, setName] = useState<string>(""); //Текущее значение названия компании
  const [isEdit, setIsEdit] = useState<boolean>(false); //Редактриуется ли текущая компания

  useEffect(() => {
    if (editingTypeProduct !== undefined) {
      form.setFieldsValue({
        name: editingTypeProduct.name,
      });
      setName(editingTypeProduct.name);
      console.log(editingTypeProduct.name);
      setIsEdit(true);
    }

    return () => {
      form.resetFields();
      setIsEdit(false);
    };
  }, [editingTypeProduct, form]);

  const handleSubmit = (e: Event) => {
    const createTypesProduct = async () => {
      const typeProduct: TypeProductObj = {
        name,
      };

      try {
        const response = await axios.post(
          `http://localhost:5075/api/TypeProduct`,
          typeProduct,
          { withCredentials: true }
        );
        console.log(response.data);
        if (response.status === 200) {
          addTypeProduct(response.data);
          form.resetFields();
        }
      } catch (error) {
        console.error("Ошибка при создании типа продукта:", error);
      }
    };

    const editTypesProduct = async (id: number | undefined) => {
      const typeProduct: TypeProductObj = {
        id,
        name,
      };

      try {
        const response = await axios.put(
          `http://localhost:5075/api/TypeProduct/${id}`,
          typeProduct,
          { withCredentials: true }
        );
        if (response.status === 200) {
          console.log(response.data);
          updateTypeProduct(response.data);
          setIsEdit(false);
          form.resetFields();
        }
      } catch (error) {
        console.error("Ошибка при редактировании типа продукта:", error);
      }
    };

    if (isEdit) {
      console.log(editingTypeProduct);
      editTypesProduct(editingTypeProduct?.id);
    } else createTypesProduct();
  };

  return (
    <Modal
      open={createModalIsShow}
      title="Форма типа продукта"
      onCancel={() => showCreateModel(false)}
      footer={[
        <Button
          key="submitButton"
          form="typeProductForm"
          type="primary"
          htmlType="submit"
          onClick={() => showCreateModel(false)}
        >
          Save
        </Button>,
        <Button key="closeButton" onClick={() => showCreateModel(false)} danger>
          Close
        </Button>,
      ]}
    >
      <Form id="typeProductForm" onFinish={handleSubmit} form={form}>
        <Form.Item
          name="name"
          label="Название типа продукта"
          hasFeedback
          rules={[
            {
              required: true,
              type: "string",
              message: "Введите название типа продукта",
            },
          ]}
        >
          <Input
            key="nameTypeProduct"
            type="text"
            name="nameTypeProduct"
            placeholder=""
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </Form.Item>
      </Form>
    </Modal>
  );
};
export default TypeProductCreate;

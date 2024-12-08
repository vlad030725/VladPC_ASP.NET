import React, { useEffect, useState } from "react";
import { Input, Modal, Button, Form, Select, InputNumber } from "antd";
import ProductObj from "../Entities/ProductObj";
import TypeProductObj from "../Entities/TypeProductObj";
import CompanyObj from "../Entities/CompanyObj";
import SocketObj from "../Entities/SocketObj";
import TypeMemoryObj from "../Entities/TypeMemoryObj";
import FormFactorObj from "../Entities/FormFactorObj";
import axios from "axios";

interface PropsType {
  editingProduct: ProductObj | undefined;
  addProduct: (product: ProductObj) => void;
  updateProduct: (product: ProductObj) => void;
  createModalIsShow: boolean;
  showCreateModel: (value: boolean) => void;
}

const ProductCreate: React.FC<PropsType> = ({
  editingProduct,
  addProduct,
  updateProduct,
  createModalIsShow,
  showCreateModel,
}) => {
  const [form] = Form.useForm(); //Создание экземпляра формы
  const [name, setName] = useState<string>(""); //Текущее значение названия компании
  const [price, setPrice] = useState<number>(0); //Текущее значение цены
  const [count, setCount] = useState<number>(0); //Текущее значение количества
  const [companies, setCompanies] = useState<Array<CompanyObj>>([]);
  const [companyCurrent, setCompanyCurrent] = useState<CompanyObj>();
  const [typesProduct, setTypesProduct] = useState<Array<TypeProductObj>>([]);
  const [typeProductCurrent, setTypeProductCurrent] = useState<
    TypeProductObj | undefined
  >();
  const [countCores, setCountCores] = useState<number | undefined>(0);
  const [countStreams, setCountStreams] = useState<number | undefined>(0);
  const [frequency, setFrequency] = useState<number | undefined>(1000);
  const [sockets, setSocket] = useState<Array<SocketObj>>([]);
  const [socketCurrent, setSocketCurrent] = useState<SocketObj | undefined>();
  const [countMemory, setCountMemory] = useState<number | undefined>(0);
  const [typeMemories, setTypeMemory] = useState<Array<TypeMemoryObj>>([]);
  const [typeMemoryCurrent, setTypeMemoryCurrent] = useState<
    TypeMemoryObj | undefined
  >();
  const [formFactors, setFormFactor] = useState<Array<FormFactorObj>>([]);
  const [formFactorCurrent, setFormFactorCurrent] = useState<
    FormFactorObj | undefined
  >();
  const [catalogString, setCatalogString] = useState<string>(""); //Текущее значение строки каталога
  const [isEdit, setIsEdit] = useState<boolean>(false);

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

    const getSockets = async () => {
      try {
        const response = await axios.get("http://localhost:5075/api/Socket", {
          withCredentials: true,
        });
        console.log(response.data);
        setSocket(response.data);
      } catch (error) {
        console.error("Ошибка при получении сокетов:", error);
      }
    };
    getSockets();

    const getTypesMemory = async () => {
      try {
        const response = await axios.get(
          "http://localhost:5075/api/TypeMemory",
          {
            withCredentials: true,
          }
        );
        console.log(response.data);
        setTypeMemory(response.data);
      } catch (error) {
        console.error("Ошибка при получении сокетов:", error);
      }
    };
    getTypesMemory();

    const getFormFactors = async () => {
      try {
        const response = await axios.get(
          "http://localhost:5075/api/FormFactor",
          {
            withCredentials: true,
          }
        );
        console.log(response.data);
        setFormFactor(response.data);
      } catch (error) {
        console.error("Ошибка при получении сокетов:", error);
      }
    };
    getFormFactors();

    if (editingProduct !== undefined) {
      console.log(editingProduct);
      form.setFieldsValue({
        typeProduct: editingProduct.idTypeProduct,
        name: editingProduct.name,
        company: editingProduct.idCompany,
        frequency: editingProduct.frequency,
        countCores: editingProduct.countCores,
        countStreams: editingProduct.countStreams,
        socket: editingProduct.idSocket,
        typeMemory: editingProduct.idTypeMemory,
        countMemory: editingProduct.countMemory,
        formFactor: editingProduct.idFormFactor,
        price: editingProduct.price,
        count: editingProduct.count,
      });
      setTypeProductCurrent(
        typesProduct[editingProduct.idTypeProduct as number]
      );
      setTypeProductCurrent(
        typesProduct[editingProduct.idTypeProduct as number]
      );
      setName(editingProduct.name);
      setCompanyCurrent(companies[editingProduct.idCompany]);
      setFrequency(editingProduct.frequency);
      setCountCores(editingProduct.countCores);
      setCountStreams(editingProduct.countStreams);
      setSocketCurrent(sockets[editingProduct.idSocket as number]);
      setTypeMemoryCurrent(typeMemories[editingProduct.idTypeMemory as number]);
      setCountMemory(editingProduct.countMemory);
      setFormFactorCurrent(formFactors[editingProduct.idFormFactor as number]);
      setPrice(editingProduct.price);
      setCount(editingProduct.count);
      setCatalogString(editingProduct.catalogString);
      console.log(editingProduct);
      setIsEdit(true);
    }
    return () => {
      form.resetFields();
      setIsEdit(false);
    };
  }, [editingProduct, form]);

  const handleSubmit = () => {
    const createProducts = async () => {
      console.log(typeProductCurrent?.id);
      const product: ProductObj = {
        name,
        price,
        count,
        idCompany: companyCurrent?.id as number,
        company: companyCurrent?.name as string,
        idTypeProduct: typeProductCurrent?.id,
        typeProduct: typeProductCurrent?.name,
        countCores: typeProductCurrent?.id == 1 ? countCores : undefined,
        countStreams: typeProductCurrent?.id == 1 ? countStreams : undefined,
        frequency,
        idSocket: typeProductCurrent?.id == 1 ? socketCurrent?.id : undefined,
        countMemory: typeProductCurrent?.id == 1 ? undefined : countMemory,
        idTypeMemory:
          typeProductCurrent?.id == 1 ? undefined : typeMemoryCurrent?.id,
        idFormFactor: undefined,
        catalogString,
      };

      console.log(product);

      try {
        const response = await axios.post(
          `http://localhost:5075/api/Product`,
          product,
          { withCredentials: true }
        );
        console.log(response.data);
        if (response.status === 200) {
          addProduct(response.data);
          form.resetFields();
        }
      } catch (error) {
        console.error("Ошибка при создании продукта:", error);
      }
    };

    const editProducts = async (id: number | undefined) => {
      const product: ProductObj = {
        id,
        name,
        price,
        count,
        idCompany: companyCurrent?.id as number,
        company: companyCurrent?.name as string,
        idTypeProduct: typeProductCurrent?.id,
        typeProduct: typeProductCurrent?.name,
        countCores: typeProductCurrent?.id == 1 ? countCores : undefined,
        countStreams: typeProductCurrent?.id == 1 ? countStreams : undefined,
        frequency,
        idSocket: typeProductCurrent?.id == 1 ? socketCurrent?.id : undefined,
        countMemory: typeProductCurrent?.id == 1 ? undefined : countMemory,
        idTypeMemory:
          typeProductCurrent?.id == 1 ? undefined : typeMemoryCurrent?.id,
        idFormFactor: undefined,
        catalogString,
      };

      try {
        const response = await axios.put(
          `http://localhost:5075/api/Product/${id}`,
          product,
          { withCredentials: true }
        );
        if (response.status === 200) {
          console.log(response.data);
          updateProduct(response.data);
          setIsEdit(false);
          form.resetFields();
        }
      } catch (error) {
        console.error("Ошибка при редактировании продукта:", error);
      }
    };
    console.log(isEdit);
    if (isEdit) {
      console.log(editingProduct);
      editProducts(editingProduct?.id);
    } else createProducts();
    setIsEdit(false);
  };

  return (
    <Modal
      open={createModalIsShow}
      title="Форма продукта"
      onCancel={() => {
        form.resetFields();
        showCreateModel(false);
      }}
      footer={[
        <Button
          key="submitButton"
          form="productForm"
          type="primary"
          htmlType="submit"
          onClick={() => {
            form.resetFields();
            handleSubmit();
            showCreateModel(false);
          }}
        >
          Save
        </Button>,
        <Button
          key="closeButton"
          onClick={() => {
            form.resetFields();
            showCreateModel(false);
          }}
          danger
        >
          Close
        </Button>,
      ]}
    >
      <Form id="productForm" onFinish={handleSubmit} form={form}>
        <Form.Item
          name="typeProduct"
          label="Тип продукта"
          hasFeedback
          rules={[
            {
              required: true,
              message: "Выберете тип продукта",
            },
          ]}
        >
          <Select
            key="typeProduct"
            onChange={(value) => setTypeProductCurrent(typesProduct[value - 1])}
          >
            {typesProduct.map((object, id) => {
              return (
                <Select.Option value={object.id} key={id}>
                  {object.name}
                </Select.Option>
              );
            })}
          </Select>
        </Form.Item>
        <Form.Item
          name="name"
          label="Название продукта"
          hasFeedback
          rules={[
            {
              required: true,
              type: "string",
              message: "Введите название продукта",
            },
          ]}
        >
          <Input
            key="name"
            type="text"
            name="nameProduct"
            placeholder=""
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </Form.Item>
        <Form.Item
          name="company"
          label="Производитель"
          hasFeedback
          rules={[
            {
              required: true,
              message: "Выберете компанию-производителя",
            },
          ]}
        >
          <Select
            key="company"
            //value={companyCurrent?.id}
            onChange={(value) => {
              console.log(companies[value - 1]);
              setCompanyCurrent(companies[value - 1]);
            }}
          >
            {companies.map((object, id) => {
              return (
                <Select.Option value={object.id} key={id}>
                  {object.name}
                </Select.Option>
              );
            })}
          </Select>
        </Form.Item>
        <Form.Item name="frequency" label="Частота, МГц" hasFeedback>
          <InputNumber
            key="frequency"
            min={0}
            max={10000}
            onChange={(value) => setFrequency(value as number)}
            style={{ width: "100%" }}
            step={100}
            //disabled={isInputDisabledFrequency}
          />
        </Form.Item>
        <Form.Item name="countCores" label="Кол-во ядер" hasFeedback>
          <InputNumber
            key="countCores"
            min={1}
            max={512}
            onChange={(value) => setCountCores(value as number)}
            style={{ width: "100%" }}
            step={2}
            //disabled={isInputDisabledCountCores}
          />
        </Form.Item>
        <Form.Item name="countStreams" label="Кол-во потоков" hasFeedback>
          <InputNumber
            key="countStreams"
            min={1}
            max={1024}
            onChange={(value) => setCountStreams(value as number)}
            style={{ width: "100%" }}
            step={2}
            //disabled={isInputDisabledCountStreams}
          />
        </Form.Item>
        <Form.Item name="socket" label="Сокет" hasFeedback>
          <Select
            key="socket"
            onChange={(value) => setSocketCurrent(sockets[value - 1])}
            //disabled={isInputDisabledSocket}
          >
            {sockets.map((object, id) => {
              return (
                <Select.Option value={object.id} key={id}>
                  {object.name}
                </Select.Option>
              );
            })}
          </Select>
        </Form.Item>
        <Form.Item name="typeMemory" label="Тип памяти" hasFeedback>
          <Select
            key="typeMemory"
            onChange={(value) => setTypeMemoryCurrent(typeMemories[value - 1])}
            //disabled={isInputDisabledTypeMemory}
          >
            {typeMemories.map((object, id) => {
              return (
                <Select.Option value={object.id} key={id}>
                  {object.name}
                </Select.Option>
              );
            })}
          </Select>
        </Form.Item>
        <Form.Item name="countMemory" label="Объём памяти, Гб" hasFeedback>
          <InputNumber
            key="countMemory"
            min={0}
            max={100000}
            onChange={(value) => setCountMemory(value as number)}
            style={{ width: "100%" }}
            step={1}
            //disabled={isInputDisabledCountMemory}
          />
        </Form.Item>
        <Form.Item name="formFactor" label="Форм фактор" hasFeedback>
          <Select
            key="formFactor"
            onChange={(value) => setFormFactorCurrent(formFactors[value - 1])}
            //disabled={isInputDisabledFormFactor}
          >
            {formFactors.map((object, id) => {
              return (
                <Select.Option value={object.id} key={id}>
                  {object.name}
                </Select.Option>
              );
            })}
          </Select>
        </Form.Item>

        <Form.Item
          name="price"
          label="Цена, руб."
          hasFeedback
          rules={[
            {
              required: true,
              message: "Введите цену",
            },
          ]}
        >
          <InputNumber
            key="price"
            min={1}
            max={1000000}
            onChange={(value) => setPrice(value as number)}
            style={{ width: "100%" }}
            step={1}
          />
        </Form.Item>
        <Form.Item
          name="count"
          label="Количество в каталоге"
          hasFeedback
          rules={[
            {
              required: true,
              message: "Введите количество",
            },
          ]}
        >
          <InputNumber
            key="count"
            min={1}
            max={1000000}
            onChange={(value) => setCount(value as number)}
            style={{ width: "100%" }}
            step={1}
          />
        </Form.Item>
      </Form>
    </Modal>
  );
};
export default ProductCreate;

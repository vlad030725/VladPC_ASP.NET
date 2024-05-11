import React, { useState } from "react";
import { Input, Button, Form } from "antd";
import { Link } from "react-router-dom";
import RegisterObj from "../Entities/RegisterObj";
import { notification } from "antd";
import axios from "axios";

interface PropsType {}

const Register: React.FC<PropsType> = () => {
  const [login, setLogin] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [passwordConfirm, setConfirmPassword] = useState<string>("");

  const [error, setError] = useState<Array<string>>([]);

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    setError([]);

    const model: RegisterObj = {
      login: login,
      password,
      passwordConfirm,
    };

    const register = async () => {
      try {
        const response = await axios.post(
          "http://localhost:5075/api/account/register",
          model,
          {
            withCredentials: true,
          }
        );

        notification.success({
          message: "Регистрация завершилась удачно",
          placement: "topRight",
          duration: 2,
        });

        if (response.data.error !== undefined) {
          console.log(response.data.error);
          setError(
            ["Регистрация завершилась неудачно "].concat(response.data.error)
          );
        } else {
          setError([response.data.message]);
        }
      } catch (error) {
        notification.error({
          message: "Регистрация завершилась неудачно",
          placement: "topRight",
          duration: 2,
        });
        console.error(error);
      }
    };

    register();
  };

  const layout = {
    labelCol: { span: 8 },
    wrapperCol: { span: 16 },
  };

  return (
    <div className="containerbox">
      <Form onFinish={handleSubmit} {...layout}>
        <h3>Регистрация</h3>
        <Form.Item
          name="login"
          label="Имя пользователя"
          hasFeedback
          rules={[
            {
              required: true,
              message: "Введите имя пользователя",
            },
          ]}
        >
          <Input name="login" onChange={(e) => setLogin(e.target.value)} />
        </Form.Item>
        <Form.Item
          name="password"
          label="Пароль"
          hasFeedback
          rules={[
            {
              required: true,
              message: "Введите пароль",
            },
            () => ({
              validator(_, value) {
                if (
                  /^.*(?=.{6,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!#$%&? _"]).*$/.test(
                    value
                  )
                )
                  return Promise.resolve();
                return Promise.reject(
                  new Error(
                    "Пароль должен должен состоять минимум из 6 символов, содержать только латинские символы, содержать заглавные, строчные буквы, цифры и специальные символы"
                  )
                );
              },
            }),
          ]}
        >
          <Input.Password
            name="password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Item>
        <Form.Item
          name="confirmPassword"
          label="Повторите пароль"
          dependencies={["password"]}
          hasFeedback
          rules={[
            {
              required: true,
              message: "Повторите пароль",
            },
            ({ getFieldValue }) => ({
              validator(_, value) {
                if (!value || getFieldValue("password") === value) {
                  return Promise.resolve();
                }
                return Promise.reject(new Error("Пароли не совпадают"));
              },
            }),
          ]}
        >
          <Input.Password
            name="confirmPassword"
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
        </Form.Item>
        <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
          <Button htmlType="submit" type="primary">
            Регистрация
          </Button>
          {error && error.map((value, key) => <p key={key}>{value}</p>)}
          <br />
          <Link to="/login">На страницу входа</Link>
        </Form.Item>
      </Form>
      <br />
    </div>
  );
};

export default Register;

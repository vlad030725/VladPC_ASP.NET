import React, { useState } from "react";
import { Input, Button, Form } from "antd";
import { Link } from "react-router-dom";
import RegisterObj from "../Entities/RegisterObj";
import { notification } from "antd";

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
      passwordConfirm
    };

    const register = async () => {

      const response = await fetch("http://localhost:5075/api/account/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(model),
      });

      if (response.ok) {
        const data = await response.json();
        notification.success({
          message: "Регистрация завершилась удачно",
          placement: "topRight",
          duration: 2,
        });
        if (data.error !== undefined) {
          console.log(data.error);
          setError(
            ["Регистрация завершилась неудачно "].concat(data.error)
          );
        } else {
          setError([data.message]);
        }
      } else {
        notification.error({
          message: "Регистрация завершилась неудачно",
          placement: "topRight",
          duration: 2,
        });
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
            }
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
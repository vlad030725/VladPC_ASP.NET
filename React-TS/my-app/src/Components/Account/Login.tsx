import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Input, Button, Form, Checkbox } from "antd";
import { Link } from "react-router-dom";
import LoginObj from "../Entities/LoginObj";
import UserObj from "../Entities/UserObj";
import { notification } from "antd";
import axios from "axios";

interface PropsType {
  setUser: (value: UserObj) => void;
}

const Login: React.FC<PropsType> = ({ setUser }) => {
  const [id, setId] = useState<number>(0);
  const [login, setLogin] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [rememberMe, setRememberme] = useState<boolean>(false);
  const [message, setMessage] = useState<Array<string>>([]);
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    setMessage([]);
    const model: LoginObj = {
      id,
      login,
      password,
      rememberMe,
    };

    const loginFunc = async () => {
      try {
        const response = await axios.post(
          "http://localhost:5075/api/account/login",
          model,
          {
            withCredentials: true, // включить куки в запросы
          }
        );

        console.log(response);

        if (response.status === 200) {
          setMessage(["Вход завершился удачно"]);
          notification.success({
            message: "Вход завершился удачно",
            placement: "topRight",
            duration: 2,
          });
          console.log(response.data.user);
          setUser(response.data.user);
          // Переход на главную страницу
          navigate("/");
        } else {
          setMessage(["Вход завершился неудачно"]);
          notification.error({
            message: "Вход завершился неудачно",
            placement: "topRight",
            duration: 2,
          });
        }
      } catch (error) {
        console.log(error);
        setMessage(["Неправильный логин или пароль"]);
      }
    };

    loginFunc();
  };

  const layout = {
    labelCol: { span: 5 },
    wrapperCol: { span: 14 },
  };

  return (
    <div className="containerbox">
      <Form onFinish={handleSubmit} {...layout}>
        <h3>Вход</h3>
        <Form.Item
          name="login"
          label="Логин"
          hasFeedback
          rules={[
            {
              required: true,
              message: "Введите логин",
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
        <Form.Item name="rememberMe" wrapperCol={{ offset: 5, span: 16 }}>
          <Checkbox
            value={rememberMe}
            onChange={(e) => setRememberme(e.target.checked)}
          >
            Запомнить?
          </Checkbox>
        </Form.Item>
        <Form.Item wrapperCol={{ offset: 5, span: 16 }}>
          {message && message.map((value, key) => <p key={key}>{value}</p>)}
          <br />
          <Button htmlType="submit" type="primary">
            Вход
          </Button>
          <br />
          <Link to="/register">На страницу регистрации</Link>
        </Form.Item>
      </Form>
      <br />
    </div>
  );
};

export default Login;

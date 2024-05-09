import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import UserObj from "../Entities/UserObj";
import { notification } from "antd";
import axios from 'axios';

interface PropsType {
  setUser: (value: UserObj | null) => void;
}

const LogOff: React.FC<PropsType> = ({ setUser }) => {
  const navigate = useNavigate();

  useEffect(() => {
          const logOff = async () => {
            await axios.post('http://localhost:5075/api/account/logoff', null, {
                withCredentials: true, // включить куки в запросы
            })
            .then(function (response) {
                if (response.status === 200) {
                    setUser(null);
                    navigate("/");
                    notification.success({
                        message: "Вы вышли из аккаунта",
                        placement: "topRight",
                        duration: 3,
                    });
                }
            })
            .catch(function (error) {
                if (error.response) {
                    notification.error({
                        message: "Вы не вошли в аккаунт",
                        placement: "topRight",
                        duration: 3,
                    });
                }
                else if (error.request) {
                    notification.error({
                        message: "Ошибка при отправке данных",
                        placement: "topRight",
                        duration: 3,
                    });
                }
                else {
                    notification.error({
                        message: "Неизвестная ошибка",
                        placement: "topRight",
                        duration: 3,
                    });
                }
                })
    };
    logOff();
  }, [navigate, setUser]);

  return <></>;
};

export default LogOff;
import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import UserObj from "../Entities/UserObj";
import { notification } from "antd";
import axios from "axios";

interface PropsType {
  setUser: (value: UserObj | null) => void;
}

const LogOff: React.FC<PropsType> = ({ setUser }) => {
  const navigate = useNavigate();

  useEffect(() => {
    const logOff = async () => {
      try {
        const response = await axios.post("http://localhost:5075/api/account/logoff", null, {
          withCredentials: true, // включить куки в запросы
        });

        if (response.status === 200) {
          setUser(null);
          navigate("/");
          notification.success({
            message: "Вы вышли из аккаунта",
            placement: "topRight",
            duration: 3,
          });
        }
      } catch (error) {
        notification.error({
          message: "Ошибка при выходе из аккаунта",
          placement: "topRight",
          duration: 3,
        });
      }
    };

    logOff(); // Вызов функции logOff при монтировании компонента
  }, []); // Теперь useEffect будет вызываться только при изменении setUser или navigate

  return null; // Компонент больше не рендерит ничего, поскольку он выполняет эффект и перенаправляет пользователя
};

export default LogOff;
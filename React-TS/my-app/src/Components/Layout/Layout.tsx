import React from "react";
import { Outlet, Link } from "react-router-dom";
import { DropdownMenu, DropdownToggle, UncontrolledDropdown, DropdownItem, NavLink } from "reactstrap";
import "bootstrap/dist/css/bootstrap.css";
import UserObj from "../Entities/UserObj";
import { Layout as LayoutAntd, Menu } from "antd";
//import "./Layout.css";

const { Header, Content, Footer } = LayoutAntd;

const defaultItems = [
  {
    label: (
      <NavLink tag={Link} to="/" style={{}}>
        VladPC
      </NavLink>
    ),
    key: "1",
  },
  {
    label: (
      <NavLink tag={Link} to="/catalog" style={{}}>
        Каталог
      </NavLink>
    ),
    key: "2",
  },
  {
    label: (
      <NavLink tag={Link} to="/profile" style={{}}>
        Профиль
      </NavLink>
    ),
    key: "3",
  },
  {
    label: (
      <NavLink tag={Link} to="/companies" style={{}}>
        Компании
      </NavLink>
    ),
    key: "4",
  },
  {
    label: (
      <NavLink tag={Link} to="/typesProduct" style={{}}>
        Типы продуктов
      </NavLink>
    ),
    key: "5",
  },
];

interface PropsType {
    user: UserObj | null;
}

const Layout: React.FC<PropsType> = ({ user }) => {
  return (
    <LayoutAntd className="layout">
      <Header
        style={{
          display: "flex",
          position: "sticky",
          top: 0,
          zIndex: 1,
          width: "100%",
          backgroundColor: "#38354f"
        }}
      >
        <Menu
          theme="dark"
          mode="horizontal"
          style={{ minWidth: "800px",
          backgroundColor: "#38354f"
          }}
          items={ defaultItems }

        ></Menu>
        <div style={{ marginLeft: "auto" }}>
          <UncontrolledDropdown>
            <DropdownToggle caret color="dark" right>
                {user ? user.userName : "Гость"}
            </DropdownToggle>
            <DropdownMenu dark right>
              <DropdownItem
                tag={Link}
                to="/register"
                disabled={user ? true : false}
              >
                Регистрация
              </DropdownItem>
              <DropdownItem
                tag={Link}
                to="/login"
                disabled={user ? true : false}
              >
                Вход
              </DropdownItem>
              <DropdownItem
                tag={Link}
                to="/logoff"
                disabled={user ? false : true}
              >
                Выход
              </DropdownItem>
            </DropdownMenu>
          </UncontrolledDropdown>
        </div>
      </Header>
      <Content className="site-layout" style={{ minHeight: "100%" }}>
        <Outlet />
      </Content>
      <Footer style={{ textAlign: "center" }}>Магазин компьютерной техники "VladPC"</Footer>
    </LayoutAntd>
  );
};
export default Layout;
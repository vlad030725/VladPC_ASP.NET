import React from "react";
import { Outlet, Link } from "react-router-dom";
import { DropdownMenu, DropdownToggle, UncontrolledDropdown, DropdownItem } from "reactstrap";
import "bootstrap/dist/css/bootstrap.css";
import UserObj from "../Entities/UserObj";
import { Layout as LayoutAntd, Menu } from "antd";
//import "./Layout.css";

const { Header, Content, Footer } = LayoutAntd;


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
        }}
      >
        <Menu
          theme="dark"
          mode="horizontal"
          style={{ minWidth: "800px" }}
        ></Menu>
        <div style={{ marginLeft: "auto" }}>
          <UncontrolledDropdown>
            <DropdownToggle caret color="dark" right>
                {user ? user.username : "Гость"}
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
                to="/logout"
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
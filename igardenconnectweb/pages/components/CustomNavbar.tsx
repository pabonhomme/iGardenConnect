import Head from "next/head";
import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import {
  Navbar,
  Nav,
} from "react-bootstrap";

const inter = Inter({ subsets: ["latin"] });

export default function CustomNavbar() {
  return (
    <>
      <Navbar bg="dark" expand="md" fixed="top" variant="dark">
        <Navbar.Brand href="/" className="ms-5">
          <img
            alt=""
            src="/logo.png"
            width="30"
            height="30"
            className="d-inline-block align-top"
          />{" "}
          iGardenConnect
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="ms-auto"></Nav>
          <Nav>
            <Nav.Link href="/login">Connexion</Nav.Link>
            <Nav.Link href="/createAccount">Créer un compte</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    </>
  );
}

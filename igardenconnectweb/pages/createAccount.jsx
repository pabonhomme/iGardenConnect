import Head from "next/head";
import React, { FormEvent } from "react";
import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import CustomNavbar from "../components/CustomNavbar";
import CustomHeader from "../components/CustomHeader";
import { Form, Button } from "react-bootstrap";
import { UserVM } from "../model/UserVM"

export default function CreateAccount() {
  let login = "";
  let password = "";

  function handleLoginChange(event) {
    login = event.target.value;
    console.log(login);
  }

  function handlePasswordChange(event) {
    password = event.target.value;
    console.log(password);
  }

  function onsubmit(event) {
    event.preventDefault();
    // create user object
    const user = new UserVM(0, "Paul", login, "user", password)
    // send post request to port 8001
    fetch('http://localhost:5241/api/User', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    }).then(response => console.log(response));
  }

  return (
    <>
      <CustomHeader />
      <main className={styles.main}>
        <header>
          <CustomNavbar />
        </header>
        <hr />
        <div className="login-container p-5">
          <h2>Créer mon compte</h2>
          <Form className="form-login" onSubmit={onsubmit}>
            <Form.Group className="mb-3" controlId="formBasiclogin">
              <Form.Label className="login-text">Saisissez un login :</Form.Label>
              <Form.Control
                className="inputText"
                type="text"
                placeholder="mon pseudo"
                onChange={handleLoginChange}
              />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label className="login-text">Saisissez un mot de passe :</Form.Label>
              <Form.Control
                className="inputText"
                type="password"
                placeholder="********"
                onChange={handlePasswordChange}
              />
            </Form.Group>

            <Button className="submit-button-createAccount bg-secondary" type="submit">
              Valider
            </Button>
          </Form>
        </div>
      </main>
    </>
  );
}

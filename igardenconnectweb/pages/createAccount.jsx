import Head from "next/head";
import React, { FormEvent } from "react";
import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import CustomNavbar from "./components/CustomNavbar";
import CustomHeader from "./components/CustomHeader";
import { Form, Button } from "react-bootstrap";

export default function CreateAccount() {
  let email = "";
  let password = "";

  function handleEmailChange(event) {
    email = event.target.value;
    console.log(email);
  }

  function handlePasswordChange(event) {
    password = event.target.value;
    console.log(password);
  }

  function onsubmit(event) {
    // event.preventDefault();
    // // create user object
    // const user = {
    //     email: email,
    //     passwd: password,
    // };
    // // send post request to port 8001
    // fetch('http://localhost:8001/api/users', {
    //     method: 'POST',
    //     headers: {
    //         'Content-Type': 'application/json'
    //     },
    //     body: JSON.stringify(user)
    // }).then(response => console.log(response));
  }

  return (
    <>
      <CustomHeader />
      <main className={styles.main}>
        <header>
          <CustomNavbar />
        </header>
        <hr />
        <div className="email-container p-5">
          <h2>Créer mon compte</h2>
          <Form className="form-login" onSubmit={onsubmit}>
            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label className="login-text">Entrer votre email :</Form.Label>
              <Form.Control
                className="inputText"
                type="email"
                placeholder="prenom.nom@gmail.com"
                onChange={handleEmailChange}
              />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label className="login-text">Entrer votre mot de passe :</Form.Label>
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

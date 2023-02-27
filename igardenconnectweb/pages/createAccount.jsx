import Head from "next/head";
import React, { FormEvent, useState } from "react";
import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import CustomNavbar from "../components/CustomNavbar";
import CustomHeader from "../components/CustomHeader";
import { Form, Button } from "react-bootstrap";
import { UserVM } from "../model/UserVM";

export default function CreateAccount() {
  const bcrypt = require("bcryptjs");
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [passwordsMatch, setPasswordsMatch] = useState(true);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(false);


  function handleLoginChange(event) {
    setLogin(event.target.value);
  }

  function handlePasswordChange(event) {
    setPassword(event.target.value);
    setPasswordsMatch(event.target.value === confirmPassword);
  }

  function handleConfirmPasswordChange(event) {
    setConfirmPassword(event.target.value);
    setPasswordsMatch(event.target.value === password);
  }

  function onSubmit(event) {
    event.preventDefault();
    if (password === confirmPassword) {
      // create user object
      const user = new UserVM(0, login, "user", bcrypt.hashSync(password, 10));      // send post request to port 5241
      fetch("http://localhost:5241/api/User", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(user),
      })
      .then((response) => {
        if (!response.ok) {
          return response.text().then((errorMessage) => {
            throw new Error(errorMessage);
        });
        }
        setSuccess(true);
        setTimeout(() => {
          window.location.href = "http://localhost:3000/login";
        }, 1000); // Attendre 1 seconde (1000 millisecondes) avant de rediriger
      })
      .catch((error) => {
        setError(error.message);
      });
    }
  }
  

  return (
    <>
      <main className={styles.main}>
        <hr />
        <div className="login-container p-5">
          <h2>Créer mon compte</h2>
          <Form className="form-login" onSubmit={onSubmit}>
            <Form.Group className="mb-3" controlId="formBasiclogin">
              <Form.Label className="login-text">Saisissez un login :</Form.Label>
              <Form.Control
                className="inputText"
                required={true}
                type="text"
                placeholder="mon pseudo"
                onChange={handleLoginChange}
              />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label className="login-text">Saisissez un mot de passe :</Form.Label>
              <Form.Control
                className="inputText"
                required={true}
                type="password"
                placeholder="********"
                onChange={handlePasswordChange}
              />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicConfirmPassword">
              <Form.Label className="login-text">
                Confirmez votre mot de passe :
              </Form.Label>
              <Form.Control
                className="inputText"
                type="password"
                placeholder="********"
                onChange={handleConfirmPasswordChange}
              />
              {error!=null && (
                <p className="alert alert-danger mt-3">{error}</p>
              )}
              {!passwordsMatch && (
                <p className="alert alert-danger mt-3">Les mots de passe ne correspondent pas</p>
              )}
              {success && passwordsMatch && (
                <p className="alert alert-success mt-3">Création de votre compte réussie</p>
              )}
            </Form.Group>

            <Button
              className="submit-button-createAccount bg-secondary"
              type="submit"
              disabled={!passwordsMatch}
            >
              Valider
            </Button>
          </Form>
        </div>
      </main>
    </>
  );
}

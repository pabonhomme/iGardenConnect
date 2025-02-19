import Head from "next/head";
import { Inter } from "@next/font/google";
import {
  Navbar,
  Nav,
} from "react-bootstrap";

const inter = Inter({ subsets: ["latin"] });

export default function CustomHeader() {
  return (
    <>
      <Head>
        <title>iGardenConnect</title>
        <meta name="description" content="Generated by create next app" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/logoiGarden.png" />
      </Head>
    </>
  );
}

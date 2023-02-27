import { Inter } from "@next/font/google";

const inter = Inter({ subsets: ["latin"] });

export default function Forbidden() {
    return (
        <>
            <div id="notauthorized">
                <div className="notauthorized">
                    <div className="notauthorized-403">
                        <h3>Oops! Page not authorized</h3>
                        <h1><span>4</span><span>0</span><span>3</span></h1>
                    </div>
                    <h2>we are sorry, but the page you requested is not authorized</h2>
                    <h2>you should try to login or create an account</h2>
                </div>
            </div>
        </>
    );
}

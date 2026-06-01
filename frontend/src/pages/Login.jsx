import { useState } from "react";
import api from "../services/api"

function Login() {
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [message, setMessage] = useState("")

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
            const response = await api.post("/auth/login", {
                email,
                password
            });

            setMessage(response.data.message);

            localStorage.setItem(
                "user",
                JSON.stringify(response.data)

            );

            console.log(response.data);
        } catch (eror) {
            setMessage("Invalid")
        }
    };

    return (


        <div>
            <h2>
                Login
            </h2>
            <form onSubmit={handleLogin}>
                <div>
                    <input
                        type="email"
                        placeholder="Email"
                        value={email}
                        onChange={(e) =>
                            setEmail(e.target.value)
                        }
                    />
                </div>

                <div>
                    <input
                        type="password"
                        placeholder="Pssword"
                        value={password}
                        onChange={(e) =>
                            setPassword(e.target.value)
                        }
                    />
                </div>
                <button type="submit">
                    Login
                </button>



            </form>
            <p>{message}</p>

        </div>
    );

}
export default Login;
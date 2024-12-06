"use client";
import Link from "next/link";
import { useState } from "react";
import { useRouter } from "next/navigation";

const LoginForm = () => {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [error, setError] = useState<string | null>(null);

  const router = useRouter();

  const handleLogIn = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      setError(null);

      const response = await fetch("API_URL", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password }),
      });

      if (!response.ok) {
        throw new Error("Invalid username or password");
      }

      router.push("/");
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
        console.error("Login failed:", error);
      } else {
        console.error(error);
      }
    }
  };

  return (
    <form
      className="bg-white outline w-[27.5rem] p-14 text-center rounded-xl"
      onSubmit={handleLogIn}
    >
      <h1 className="font-bold text-3xl mb-5">Welcome Back!</h1>
      <div className="flex flex-col gap-3 justify-center items-center">
        {error && <p className="text-red-500 font-medium">{error}</p>}
        <input
          className="outline p-2 rounded-xl w-full mb-2"
          placeholder="Username"
          type="text"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
        <input
          className="outline p-2 rounded-xl w-full mb-2"
          placeholder="Password"
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />

        <button
          className="bg-emerald-400 rounded-3xl w-32 p-2 font-bold"
          type="submit"
        >
          Log In
        </button>
        <div className=" flex flex-row justify-center gap-1">
          <p>Don't have an account?</p>
          <Link href="/signup" className="text-blue-500 font-bold">
            Sign Up
          </Link>
        </div>
      </div>
    </form>
  );
};

export default LoginForm;

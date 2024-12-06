"use client";
import Link from "next/link";
import { useState } from "react";
import { useRouter } from "next/navigation";

const SignUpForm = () => {
  const [email, setEmail] = useState<string>("");
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [comfirmPassword, setComfirmPassword] = useState<string>("");
  const [error, setError] = useState<string | null>(null);

  const router = useRouter();

  const hanldeSignUp = async (e: React.FormEvent) => {
    e.preventDefault();

    if (password !== comfirmPassword) {
      setError("Passwords do not match.");
      return;
    }

    try {
      setError(null);
      const response = await fetch("API_URL", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email, username, password }),
      });

      if (!response.ok) {
        throw new Error("Faild to sign up. Please try again.");
      }

      console.log("Sign in successful");
      router.push("/");
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
      } else {
        setError("An unexpected error occurred.");
      }
    }
  };

  return (
    <form
      className="bg-white outline w-[29rem] p-14 text-center rounded-xl"
      onSubmit={hanldeSignUp}
    >
      <h1 className="text-2xl font-bold mb-2">Welcome to ShopQuik!</h1>
      <h2 className="text-xl font-bold mb-10">Sign Up Start Shopping</h2>
      <div className="flex flex-col items-center">
        {error && <p className="text-red-500 mb-3">{error}</p>}
        <input
          className="outline p-2 rounded-xl w-full mb-3"
          placeholder="Email Address"
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
        <input
          className="outline p-2 rounded-xl w-full mb-3"
          placeholder="Username"
          type="text"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
        <input
          className="outline p-2 rounded-xl w-full mb-3"
          placeholder="Password"
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
        <input
          className="outline p-2 rounded-xl w-full mb-5"
          placeholder="Confirm Password"
          type="password"
          value={comfirmPassword}
          onChange={(e) => setComfirmPassword(e.target.value)}
          required
        />
        <button
          className="rounded-3xl font-bold bg-emerald-400 w-32 p-2"
          type="submit"
        >
          Sign Up
        </button>
        <div className=" flex flex-row justify-center gap-1">
          <p>Already have an account?</p>
          <Link href="/login" className="text-blue-500 font-bold">
            Log In
          </Link>
        </div>
      </div>
    </form>
  );
};

export default SignUpForm;

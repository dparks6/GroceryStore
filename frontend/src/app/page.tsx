"use client"

import Image from "next/image";
import Navbar from "../components/header/Navbar";
import { ProductCards } from "@/components/products/ProductCards";

const Home = () => {
  return (
    <main className="min-h-screen">
      <Navbar />
      <section className="px-44 py-32">
        <div className="flex flex-col gap-10">
          <ProductCards title={"Produce"} />
          <ProductCards title={"Meat"} />
        </div>
      </section>
    </main>
  );
};

export default Home;

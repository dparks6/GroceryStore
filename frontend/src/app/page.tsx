import Navbar from "./navbar/Navbar";
import { ProductCards } from "@/components/products/ProductCards";

const Home = () => {
  return (
    <main className="min-h-screen">
      <Navbar />
      <section className="p-20">
        <div className="flex flex-col gap-10">
          <ProductCards title={"Produce"} />
          <ProductCards title={"Meat"} />
        </div>        
      </section>

    </main>
  );
};

export default Home;

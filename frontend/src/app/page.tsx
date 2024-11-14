import { ProductCards } from "@/components/products/ProductCards";


const Home = () => {
  return (
    <main className="min-h-screen p-20">
      <div className="flex flex-col gap-10">
        <ProductCards title={"Produce"}/>
        <ProductCards title={"Meat"}/>        
      </div>
    </main>
  );
};

export default Home;

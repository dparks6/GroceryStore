import { section } from "framer-motion/client";
import Image from "next/image";
import { IoIosAdd } from "react-icons/io";

interface ProductType {
  productID: number;
  name: string;
  description: string;
  price: number;
  images: string;
  manufacturer: string;
  dimensions: string;
  weight: number;
  rating: number;
  sku: string;
  categoryID: number;
  stock: number;
  saleID: number;
  discountedPrice: number;
}

const fetchProducts = async (id: number) => {
  const response = await fetch(
    `http://localhost:5058/api/product/category/${id}`
  );

  return response.json();
};
const Cards = async () => {
  const responseFreshProduce = await fetchProducts(1);
  const responseDairy = await fetchProducts(2);
  const responseDeli = await fetchProducts(3);

  const sections = [
    { title: "Fresh Produce", products: responseFreshProduce },
    { title: "Dairy", products: responseDairy },
    { title: "Deli", products: responseDeli },
  ];

  return (
    <div className="p-5">
      {sections.map((section) => (
        <div key={section.title} className="mb-10">
          <h2 className="text-2xl font-bold mb-5">{section.title}</h2>
          <div className="flex gap-5">
            {section.products.map((product: ProductType) => (
              <div
                key={product.productID}
                className="bg-zinc-950 p-5 rounded-xl min-w-[250px] flex-shrink-0 transition-transform transform hover:scale-105"
              >
                <Image
                  src={"/img/dummy_img/apple.jpg" || product.images}
                  alt="Honeycrisp Apple"
                  width={300}
                  height={300}
                  className="h-[16rem] w-[20rem] object-cover rounded-md"
                />
                <div className="flex flex-row items-center justify-between mt-3">
                  <h2 className="font-bold">{product.name}</h2>
                  <button className="rounded-full p-1 bg-pink-500 hover:bg-pink-600">
                    <IoIosAdd className="text-white text-3xl" />
                  </button>
                </div>
                <div className="flex flex-col gap-2 mt-6">
                  <p>${product.price}</p>
                  <p className="text-zinc-400 text-sm">{product.description}</p>
                </div>
              </div>
            ))}
          </div>
        </div>
      ))}
    </div>
  );
};

export default Cards;

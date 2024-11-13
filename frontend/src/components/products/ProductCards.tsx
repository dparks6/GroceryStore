"use client";
import { Carousel, Card } from "@/components/ui/CardCarousel";

export function ProductCards() {
  const cards = data.map((card, index) => (
    <Card key={card.src} card={card} index={index} />
  ));

  return (
    <div className="w-full h-full mt-10">
      <h2 className="pl-4 mx-auto text-xl md:text-3xl font-bold text-neutral-800 font-sans">
        Recommended for you
      </h2>
      <Carousel items={cards} />
    </div>
  );
}

const DummyContent = () => {
  return (
    <>
      {[...new Array(1).fill(1)].map((_, index) => {
        return (
          <div
            key={"dummy-content" + index}
            className="bg-neutral-800 p-8 md:p-14 rounded-3xl mb-4"
          >
            <div className="text-neutral-400 text-base md:text-2xl font-sans max-w-3xl mx-auto">
              <p className="font-bold text-neutral-200">
                Description:
              </p>{" "}
              <p className="font-bold text-neutral-200">
                Manufacturer:
              </p>{" "}
              <p className="font-bold text-neutral-200">
                Weight:
              </p>{" "}
              <p className="font-bold text-neutral-200">
                Rating:
              </p>{" "}
              <p className="font-bold text-neutral-200">
                SKU:
              </p>{" "}
              <p className="font-bold text-neutral-200">
                Stock
              </p>{" "}
            </div>
          </div>
        );
      })}
    </>
  );
};

const data = [
  {
    category: "Apples",
    src: "/img/dummy_img/apple.jpg",
    content: <DummyContent />,
  },
  {
    category: "Bananas",
    src: "/img/dummy_img/banana.jpg",
    content: <DummyContent />,
  },
  {
    category: "Cookies",
    src: "/img/dummy_img/cookie.jpg",
    content: <DummyContent />,
  },
  {
    category: "Pies",
    src: "/img/dummy_img/pie.jpg",
    content: <DummyContent />,
  },
  {
    category: "Chicken",
    src: "/img/dummy_img/chicken.jpg",
    content: <DummyContent />,
  },
  {
    category: "Pizza",
    src: "/img/dummy_img/pizza.jpg",
    content: <DummyContent />,
  },
  {
    category: "Beef",
    src: "/img/dummy_img/steak.jpg",
    content: <DummyContent />,
  },
  {
    category: "Soda",
    src: "/img/dummy_img/soda.jpg",
    content: <DummyContent />,
  },

];

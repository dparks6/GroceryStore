"use client";
import { Carousel, Card } from "@/components/ui/CardCarousel";
import { ProductPost } from "@/data/DUMMY_DATA";

type ProductCardsProps = {
  title: string;
};

export function ProductCards({ title }: ProductCardsProps) {
  const filteredCards = ProductPost.filter(
    (product) => product.category === title
  );

  const cards = filteredCards.map((card, index) => (
    <Card key={card.image} card={card} index={index} />
  ));

  return (
    <div className="w-full h-full bg-white p-4 pt-6 flex flex-col shadow-md">
      <h2 className="pl-4 text-xl md:text-3xl font-bold text-neutral-800 font-sans">
        {title}
      </h2>
      <Carousel items={cards} />
    </div>
  );
}

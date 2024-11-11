import { FlipWords } from "@/components/ui/FlipWords";

const layout = ({ children }: { children: React.ReactNode }) => {
  return (
    <main className="flex flex-row">
      <section className="flex w-1/2">
        {children}
      </section>
      <div className="flex flex-col justify-center w-1/2 text-6xl">
        <h1>Shop <FlipWords words={["easier", "faster", "seemlessly"]} /></h1>
        <h1>with our online Grocery Store</h1>
      </div>
    </main>
  );
};

export default layout;

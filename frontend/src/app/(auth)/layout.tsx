const layout = ({ children }: { children: React.ReactNode }) => {
  return (
    <main className="flex flex-row">
      <section className="flex w-1/2">
        {children}
      </section>
      <div className="w-1/2">
        <p>*photo goes here*</p>
      </div>
    </main>
  );
};

export default layout;

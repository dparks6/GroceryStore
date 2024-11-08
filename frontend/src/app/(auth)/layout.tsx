const layout = ({ children }: { children: React.ReactNode }) => {
  return (
    <main className="p-4">
      <section>{children}</section>
    </main>
  );
};

export default layout;

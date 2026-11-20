
import type { Metadata } from "next";
import "./globals.css";

export const metadata: Metadata = {
  title: "IA-WAITER | Menú Digital",
  description:
    "Explora nuestro menú digital y disfruta de una experiencia gastronómica.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="es">
      <body>{children}</body>
    </html>
  );
}

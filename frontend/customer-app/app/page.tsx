
import Image from "next/image";

export default function Home() {
  return (
    <main className="min-h-screen bg-[#faf9f6] text-[#242820]">
      <header className="border-b border-[#e9e6df] bg-white">
        <div className="mx-auto flex max-w-6xl items-center justify-between px-5 py-5">
          <div>
            <h1 className="text-2xl font-bold tracking-[0.12em] text-[#253d32]">
              IA WAITER
            </h1>
            <p className="mt-1 text-[10px] tracking-[0.25em] text-[#8a9188]">
              EXPERIENCIA GASTRONÓMICA
            </p>
          </div>

          <div className="rounded-full bg-[#edf2ec] px-4 py-2 text-sm font-medium text-[#385342]">
            Menú digital
          </div>
        </div>
      </header>

      <section className="mx-auto max-w-6xl px-5 py-12">
        <div className="overflow-hidden rounded-3xl bg-[#253d32] px-7 py-12 text-white md:px-12 md:py-16">
          <p className="mb-4 text-xs font-medium tracking-[0.3em] text-[#c6d4c5]">
            BIENVENIDO
          </p>

          <h2 className="max-w-xl text-4xl font-semibold leading-tight md:text-5xl">
            Descubre nuestro menú.
          </h2>

          <p className="mt-5 max-w-md text-sm leading-7 text-[#d1dbd0]">
            Explora nuestras opciones y disfruta de una experiencia
            gastronómica especial.
          </p>

          <div className="mt-8 inline-flex items-center gap-2 rounded-full border border-white/20 px-5 py-3 text-sm">
            <span className="h-2 w-2 rounded-full bg-[#a8c49e]" />
            Mesa pendiente de identificar
          </div>
        </div>

        <div className="mt-12">
          <div className="flex items-end justify-between">
            <div>
              <p className="text-xs font-semibold tracking-[0.2em] text-[#92978e]">
                NUESTRA CARTA
              </p>

              <h3 className="mt-2 text-3xl font-semibold text-[#253d32]">
                Menú
              </h3>
            </div>
          </div>

          <div className="mt-8 rounded-2xl border border-[#e9e6df] bg-white p-8 text-center">
            <div className="mx-auto flex h-14 w-14 items-center justify-center rounded-full bg-[#edf2ec] text-2xl">
              🍽️
            </div>

            <h4 className="mt-5 text-lg font-semibold">
              Tu menú te espera
            </h4>

            <p className="mx-auto mt-2 max-w-sm text-sm leading-6 text-[#858a82]">
              Escanea el código QR de tu mesa para visualizar los productos
              disponibles y realizar tu pedido.
            </p>
          </div>
        </div>
      </section>

      <footer className="border-t border-[#e9e6df] bg-white py-7 text-center">
        <p className="text-xs tracking-wide text-[#92978e]">
          IA WAITER · MENÚ DIGITAL
        </p>
      </footer>
    </main>
  );
}

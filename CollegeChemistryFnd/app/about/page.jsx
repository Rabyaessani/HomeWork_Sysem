async function getAbout() {
  try {
    const res = await fetch(process.env.BACKEND_URL + "/api/about", {
      cache: "no-store",
    });

    if (!res.ok) {
      throw new Error("Failed to fetch data");
    }

    return await res.json();
  } catch (error) {
    console.error("Error fetching about content:", error);
    return null;
  }
}

export const metadata = {
  title: "About",
  description: "About the site",
  type: "article",
  openGraph: {
    title: "About",
    description: "About the site",
    type: "article",
  },
};

export default async function about() {
  const data = await getAbout();
  const about = data?.data;

  if (about == null) {
    return (
      <main className="container p-3 grid place-content-center min-h-screen">
        <h1 className="text-4xl font-bold pb-9">About Us not Published Yet</h1>
      </main>
    );
  }

  return (
    <main
      className="container prose lg:prose-lg xl:prose-xl dark:prose-invert ck-content mx-auto py-6 sm:px-0 px-3"
      dangerouslySetInnerHTML={{ __html: about.attributes.content }}
    ></main>
  );
}

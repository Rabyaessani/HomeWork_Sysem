import { fetchDataWithAuth } from '../apiUtil'; // Make sure to import the utility function

const getAbout = async () => {
  try {
    const url = `${process.env.BACKEND_URL}/api/about`;

    // Call the utility function to fetch data
    const data = await fetchDataWithAuth(url);

    return data; // Return the fetched blogs
  } catch (error) {
    return { error: error.message || 'An error occurred' };
  }
};
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

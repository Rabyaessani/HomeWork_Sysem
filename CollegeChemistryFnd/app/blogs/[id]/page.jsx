async function getBlog(id) {
  try {
    const res = await fetch(
      `${process.env.BACKEND_URL}/api/blogs/getblogbyid?id=${id}`,
      {
        cache: "no-store",
      }
    );

    // Check if the response is not OK (e.g., 404 or 500)
    if (!res.ok) {
      throw new Error("Failed to fetch blog data");
    }

    return await res.json();
  } catch (error) {
    console.error("Error fetching blog data:", error);
    return null; // Return null if the fetch request fails
  }
}

export async function generateMetadata({ params }) {
  const data = await getBlog(params.id);

  // If the data is null or empty, return metadata for a 404-like page
  if (!data || data.length === 0) {
    return {
      title: "Blog not found",
      description: "The requested blog was not found",
      openGraph: {
        title: "Blog not found",
        description: "The requested blog was not found",
        type: "article",
      },
    };
  }

  // Extract blog data and return metadata if the blog exists
  const blog = data;
  return {
    title: blog.title,
    description: blog.description,
    type: "article",
    openGraph: {
      title: blog.title,
      description: blog.description,
      type: "article",
      // Optionally include image URLs
      // images: [
      //   `${process.env.BACKEND_URL}${blog.attributes.cover.data.attributes.url}`,
      // ],
    },
  };
}

export default async function page({ params }) {
  const data = await getBlog(params.id);

  // If no data is returned, show a fallback message
  if (!data) {
    return (
      <main className="container p-3 grid place-content-center min-h-screen">
        <h1 className="text-4xl font-bold pb-9">Blog not found</h1>
      </main>
    );
  }

  const blog = data;

  return (
    <main
      className="container p-4 prose dark:prose-invert mx-auto prose-lg ck-content"
      dangerouslySetInnerHTML={{ __html: blog.content }}
    ></main>
  );
}

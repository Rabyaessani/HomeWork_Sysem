import { Card, CardBody, CardHeader, Image } from "@nextui-org/react";
import NextLink from "next/link";
import NextImage from "next/image";
import MyPagination from "./pagination";
import { fetchDataWithAuth } from '../apiUtil'; // Make sure to import the utility function

const getBlogs = async () => {
  try {
    const url = `${process.env.BACKEND_URL}/api/blogs/allPublishedBlogs`;

    // Call the utility function to fetch data
    const data = await fetchDataWithAuth(url);

    return data; // Return the fetched blogs
  } catch (error) {
    return { error: error.message || 'An error occurred' };
  }
};
export const metadata = {
  title: "Blogs",
  description: "Blogs",
  type: "article",
  openGraph: {
    title: "Blogs",
    description: "Blogs",
    type: "article",
  },
};

function BlogCard({ blog }) {
  return (
    <Card
      className="bg-background/35 max-w-[330px] hover:cursor-pointer group "
      radius="sm"
      shadow="sm"
      as={NextLink}
      href={"/blogs/" + blog.id}
    >
      <CardHeader className="">
        <Image
          as={NextImage}
          src={`data:image/jpeg;base64,${blog.cover_picture}`}
          className="w-[320px] h-[210px]  object-cover rounded-none "
          alt={blog.title}
          width={400}
          height={400}
        />
      </CardHeader>
      <CardBody className="">
        <h3 className="font-semibold text-3xl group-hover:text-pink-600">
          {blog.title}
        </h3>
        <p className="line-clamp-3 text-small pt-3 ">
          {blog.description}
        </p>
      </CardBody>
    </Card>
  );
}

export default async function blogs({ searchParams }) {
  //const starting_limit = searchParams["limit"] || 10;
  const data = await getBlogs();
  if (data.error) {
    return (
      <main className="container-fluid grid place-content-center min-h-screen">
        <h1 className="text-4xl font-bold pb-9">Error while fetching blogs</h1>
      </main>
    );
  }

  if (data.length === 0) {
    return (
      <main className="container-fluid grid place-content-center min-h-screen">
        <h1 className="text-4xl font-bold pb-9">No blogs Published Yet</h1>
      </main>
    );
  }

  return (
    <main className="container-fluid grid place-content-center min-h-screen">
      <h1 className="text-4xl font-bold pb-9">Blogs</h1>
      <div className="grid grid-cols-1 gap-4 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
        {data.map((blog, idx) => (
          <BlogCard key={blog.id + idx} blog={blog} />
        ))}
      </div>
      {/* <MyPagination total={data.meta.pagination.total} limit={starting_limit} /> */}
    </main>
  );
}

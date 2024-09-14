import React from "react";
import {
  Card,
  CardHeader,
  CardBody,
  Image,
  CardFooter,
  Chip,
} from "@nextui-org/react";
import NextImage from "next/image";
import CategorySelect from "./categoryselect";
import NextLink from "next/link";
import MyPagination from "./pagination";

export const metadata = {
  title: "Lessons",
};

async function getLessons() {
  try {
    const res = await fetch(
      `${process.env.BACKEND_URL}/api/lessons/allPublishedLessons?ispublish=true`,
      {
        cache: "no-store",
      }
    );

    return res.json();
  } catch (error) {
    return { error: error.message || "An error occured" };
  }
}

// async function getCategories() {
//   try {
//     const res = await fetch(process.env.BACKEND_URL + "/api/categories", {
//       cache: "no-store",
//     });
//     return res.json();
//   } catch (error) {
//     return { error: error.message || "An error occured" };
//   }
// }

function CardComponent({ lesson }) {
  return (
    <Card
      className="max-w-[300px] group hover:shadow-lg transition duration-300 ease-in-out rounded-lg overflow-hidden shadow-lg "
      radius="none"
      as={NextLink}
      href={"/lessons/" + lesson.id}
    >
      <CardHeader className="p-0">
        {lesson?.cover_picture ? (
          <Image
            src={`data:image/jpeg;base64,${lesson.cover_picture}`}
            as={NextImage}
            alt={lesson.title}
            className="w-[300px] h-[220px] object-cover rounded-none"
            width={300} 
            height={220} 
          />
        ) : null}{" "}
       
      </CardHeader>
      <CardBody className="">
        <h1 className="text-2xl font-bold group-hover:text-pink-600">
          {lesson.title}
        </h1>
        <p className="pt-1 text-sm line-clamp-3 ">{lesson.description}</p>
      </CardBody>
      {/* <CardFooter className="gap-2 flex flex-row flex-wrap pt-0">
        {lesson.attributes.categories.data.map((category) => (
          <Chip
            key={category.attributes.name}
            size="sm"
            variant="solid"
            color="primary"
            style={{
              color: "white",
            }}
          >
            # {category.attributes.name}
          </Chip>
        ))}
      </CardFooter> */}
    </Card>
  );
}

export default async function lessons() {
  //const category = searchParams["category"] ?? "";
  //const limit = searchParams["limit"] || 10;
  const data = await getLessons();
  console.log("data", data);
  //const lessons = data;

  if (data.error) {
    return (
      <main className="container p-3 grid place-content-center min-h-screen">
        <h1 className="text-4xl font-bold pb-9">
          Error while fetching Lessons
        </h1>
      </main>
    );
  }
  if (data.length === 0) {
    return (
      <main className="container p-3 grid place-content-center min-h-screen">
        <h1 className="text-4xl font-bold pb-9">No Lessons Published Yet</h1>
      </main>
    );
  }

  // const categories = await getCategories();
  // if (categories.error) {
  //   return (
  //     <main className="container p-3 grid place-content-center min-h-screen">
  //       <h1 className="text-4xl font-bold pb-9">
  //         Error while fetching Categories
  //       </h1>
  //     </main>
  //   );
  // }

  return (
    <main className="container mx-auto grid p-5 justify-center min-h-[90vh]">
      {/* {categories.data.length > 0 && (
        <div className="w-fit md:ml-auto md:mr-0 ml-auto mr-auto">
          <CategorySelect
            categories={categories.data}
            limit={limit}
            category={category}
          />
        </div>
      )} */}

      <section className="grid sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4  gap-4 place-content-center">
        {data.map((lesson) => (
          <CardComponent lesson={lesson} key={lesson.id} />
        ))}
      </section>
      {/* <MyPagination
        total={data.meta.pagination.total}
        imit={limit}
       category={category}
      /> */}
    </main>
  );
}

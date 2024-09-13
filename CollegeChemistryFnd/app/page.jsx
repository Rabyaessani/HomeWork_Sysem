import NextImage from "next/image";
import ScienceBroS from "../public/chemistry-lab-animate.svg";
import { DisplayBlogs } from "./components/BlogCard";

// async function getFirstSix() {
//   const res = await fetch(
//     process.env.BACKEND_URL +
//       "/api/blogs/allblogs",
//     {
//       cache: "no-store",
//     }
//   );
//   return res.json();
// }

async function getFirstSix() {
  try {
    const res = await fetch(
      process.env.BACKEND_URL + "/api/blogs/allblogs",
      {
        cache: "no-store",
      }
    );
    
    // Check if the response is ok (status code in the range 200-299)
    if (!res.ok) {
      throw new Error(`Failed to fetch: ${res.status} ${res.statusText}`);
    }
    
    const data = await res.json();
    console.log("data",data)
    return data;
    
  } catch (error) {
    console.log("Error fetching blogs:", error);
    return error; // or handle it as per your requirement
  }
}


function TypographyH1({ content }) {
  return (
    <h1 className="scroll-m-20 text-4xl font-extrabold tracking-tight lg:text-5xl bg-clip-text text-transparent bg-gradient-to-r from-pink-400 via-fuchsia-500 to-rose-600 sm:text-left text-center">
      {content}
    </h1>
  );
}

function TypographyH2({ content }) {
  return (
    <h2 className="scroll-m-20 pb-2 sm:px-0 px-2 text-2xl sm:text-3xl font-semibold tracking-tight first:mt-0 text-foreground">
      {content}
    </h2>
  );
}
function TypographyH3({ children }) {
  return (
    <h3 className="scroll-m-20 sm:text-2xl text-xl font-semibold tracking-tight text-center sm:text-left px-3">
      {children}
    </h3>
  );
}

export default async function Home() {
   const data2 = await getFirstSix();
   console.log("data2",data2)
   console.log("Hello world")
  const first_six = data2.data;
  return (
    <main>
      <section className="sm:h-[calc(100vh-65px)] md:bg-blob-haikei bg-contain bg-no-repeat flex flex-col-reverse sm:flex-row-reverse justify-evenly items-center mr-6">
        <div className="sm:w-[50%] w-[calc(100vw-12px)] flex flex-col gap-5 mx-auto">
          <TypographyH1 content="Stay ahead of the curve in the ever-evolving field of chemistry." />
          <TypographyH3>
            &quot;Unlock the World of Elements: Where Chemistry Comes to Life -
            Lessons, Insights, and Discoveries Await&quot;
          </TypographyH3>
        </div>
        <div className="">
          <NextImage
            src={ScienceBroS}
            priority={100}
            alt="image of a science bro"
          />
        </div>
      </section>
      <section className="flex flex-col gap-4 items-center py-7 after:content-[''] after:bg-pink-200   after:absolute relative after:inset-0 after:skew-y-3 after:-z-10 ">
        <TypographyH2 content={"Explore some Latest Blog Posts"} />
        <div
          id="blogs"
          className="grid place-content-center grid-cols-3 gap-4  w-fit"
        ></div>
        <DisplayBlogs blogs={first_six} />
        {/* <DisplayBlogs/> */}
      </section>
    </main>
  );
}

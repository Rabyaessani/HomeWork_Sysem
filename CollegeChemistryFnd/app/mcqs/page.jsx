import React from "react";
import { Link } from "@nextui-org/react";
import NextLink from "next/link";
import sanitizeHtml from 'sanitize-html';

async function getMcqs() {
  try {
    const res = await fetch(process.env.BACKEND_URL + "/api/questions/allQuestions", {
      cache: "no-store",
    });
    return res.json();
  } catch (error) {
    return { error: error.message || "Error while fetching MCQs" };
  }
}

export const metadata = {
  title: "MCQs",
  description: "MCQs for practice",
  openGraph: {
    title: "MCQs",
    description: "MCQs for practice",
  },
};

async function page() {
  const data = await getMcqs();
  
  if (data.error) {
    return (
      <main className="container p-4 mx-auto min-h-screen grid place-content-center">
        Error while fetching MCQs
      </main>
    );
  }

  if (data.length === 0) {
    return (
      <main className="container p-4 mx-auto min-h-screen grid place-content-center">
        <h1 className="text-3xl font-semibold">No MCQs Published Yet</h1>
      </main>
    );
  }

  const mcqs = data; // Assuming the API response is directly an array of MCQs
 
  return (
    <main className="container p-4 mx-auto min-h-screen">
      <h1 className="text-3xl font-bold">MCQs</h1>
      <ol className="py-6 flex flex-col">
        {mcqs.map((mcq, key) => (
          <Link
            href={`/mcqs/${mcq.id}`} // Using mcq.id since there's no slug field in the data provided
            key={mcq.id}
            size="lg"
            className="text-pink-400 dark:text-white font-extrabold text-xl transition-all duration-300 ease-in-out hover:underline"
            as={NextLink}
          >
            {/* {key + 1}. {mcq.question}  */}
            <div className="flex flex-row gap-3 bg-foreground-100/50 sm:p-5 py-5 px-2 rounded-xl mb-3">
              <span className="card-number">{key + 1}.</span>
              <span className="card-text" dangerouslySetInnerHTML={{ __html: mcq.question }} />
            </div>
          </Link>
        ))}
      </ol>
    </main>
  );
}

export default page;

import React from "react";
import sanitizeHtml from 'sanitize-html';
import McqCard from "./mcqcard";

// Fetch the question by its ID using the new API
async function getMcqById(id) {
  console.log("ID passed to function:", id);
  try {
    const res = await fetch(
      `${process.env.BACKEND_URL}/api/questions/getQuestionbyid?id=${id}`,
      {
        cache: "no-store",
      }
    );

    if (!res.ok) {
      throw new Error(`HTTP error! Status: ${res.status}`);
    }

    const data = await res.json();

    // Log the data to the console
    console.log("Fetched MCQ Data:", data);

    return data;
  } catch (error) {
    // Log the error to the console
    console.error("Error while fetching the MCQ:", error.message || error);
    
    return { error: error.message || "Error while fetching the MCQ" };
  }
}


// Set metadata based on the question details
export async function generateMetadata({ params }) {
  console.log('params',params)
  const data = await getMcqById(params.id);
  
  if (!data || data.error) {
    return {
      title: "MCQ not found",
    };
  } else {
    const mcq = data; // Assuming the fetched response directly contains the MCQ
    return {
      title: mcq.question || "MCQ",
      description: `Test your knowledge on: ${mcq.question}`,
      openGraph: {
        title: mcq.question || "MCQ",
        description: `Test your knowledge on: ${mcq.question}`,
      },
    };
  }
}

// Main page component that renders the question data
async function page({ params }) {
  const data = await getMcqById(params.id);

  if (!data || data.error) {
    return (
      <main className="container p-4 mx-auto grid place-content-center">
        <h1 className="text-3xl font-bold">MCQ not found</h1>
      </main>
    );
  }

  const mcq = data; // Assuming the structure of data contains the MCQ
  const sanitizedQuestionText = sanitizeHtml(mcq.question);
  return (
    <main className="container p-4 mx-auto grid place-content-center gap-6 w-full">
      <h1 className="text-3xl font-bold mb-4"
        dangerouslySetInnerHTML={{ __html: sanitizedQuestionText }}
      />
      <McqCard
        key={mcq.id}
        question_text={mcq.question}
        correct_option={mcq.correct_option}
        option_a={mcq.option_a}
        option_b={mcq.option_b}
        option_c={mcq.option_c}
        option_d={mcq.option_d}
        id={mcq.id}
      />
    </main>
  );
}

export default page;

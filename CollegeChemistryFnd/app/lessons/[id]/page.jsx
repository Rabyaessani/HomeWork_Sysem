async function getLesson(id) {
  const res = await fetch(
    `${process.env.BACKEND_URL}/api/lessons/getlessonbyid?id=${id}`,
    {
      cache: "no-store",
    }
  );
  return res.json();
}

export async function generateMetadata({ params }) {
  const data = await getLesson(params.id);
  //const lesson = data.data[0];
  if (data.length === 0) {
    return {
      title: "Lesson not found",
    };
  } else {
    const lesson = data;
    
    return {
      title: lesson.title,
      description: lesson.description,
      type: "article",
      openGraph: {
        title: lesson.title,
        description: lesson.description,
        type: "article",
        // images: [
        //   process.env.BACKEND_URL + lesson.attributes.cover.data.attributes.url,
        // ],
      },
    };
  }
}
function getYouTubeVideoId(url) {
  // Check if the URL contains "watch?v=" to extract the video ID
  const videoId = url.includes("watch?v=") ? url.split("watch?v=")[1] : url;
  return videoId.split("&")[0]; // In case there are additional parameters in the URL
}

async function page({ params }) {
  const data = await getLesson(params.id);
  const lesson = data;
  const youtubeVideoId = lesson.youtube_video ? getYouTubeVideoId(lesson.youtube_video) : null;

  return (
    <main className="container p-4 prose dark:prose-invert mx-auto ">
      {lesson.youtube_video && (
        <div className="w-full">
          <iframe
            src={`https://www.youtube.com/embed/${youtubeVideoId}`}
            frameBorder="0"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
            allowFullScreen
            className="aspect-video w-full"
          ></iframe>
        </div>
      )}
      <div
        className="prose dark:prose-invert mt-9"
        dangerouslySetInnerHTML={{ __html: lesson.content }}
      ></div>
    </main>
  );
}

export default page;

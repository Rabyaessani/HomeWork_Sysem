"use client";

import React, { useState } from "react";
import { CheckboxGroup, Checkbox } from "@nextui-org/react";
import { cn } from "@nextui-org/react";
import sanitizeHtml from 'sanitize-html';

// Custom radio component
export const CustomRadio = (props) => {
  const { children, color, ...otherProps } = props;

  return (
    <Checkbox
      {...otherProps}
      classNames={{
        base: cn(
          "inline-flex m-0 bg-content1 hover:bg-content2 items-center",
          "w-full max-w-[800px] cursor-pointer rounded-lg gap-4 p-4 border-2 border-transparent",
          {
            "data-[selected=true]:border-success": color === "success",
            "data-[selected=true]:border-danger": color === "danger",
          }
        ),
      }}
    >
      {children}
    </Checkbox>
  );
};

// MCQ Card component
export default function McqCard({
  question_text,
  correct_option,
  option_a,
  option_b,
  option_c,
  option_d,
  id,
}) {
  const [selected, setSelected] = useState("");

  const sanitizedQuestionText = sanitizeHtml(question_text);
  

  const handleChange = (value) => {
    const lastItem = value[value.length - 1];
    setSelected(lastItem);
  };

  return (
    <div className="flex flex-col gap-3 bg-foreground-100/50 sm:p-5 py-5 px-2 rounded-xl">
      <CheckboxGroup
        label={`${id}. ${question_text}`}
        value={[selected]}
        onValueChange={handleChange}
        size="sm"
        className="text-3xl"
      >
        <CustomRadio
          value="A"
          color={selected === "A" ? (correct_option === "A" ? "success" : "danger") : undefined}
        >
            <span dangerouslySetInnerHTML={{ __html: option_a }} />
        </CustomRadio>
        <CustomRadio
          value="B"
          color={selected === "B" ? (correct_option === "B" ? "success" : "danger") : undefined}
        >
           <span dangerouslySetInnerHTML={{ __html: option_b }} />
        </CustomRadio>
        <CustomRadio
          value="C"
          color={selected === "C" ? (correct_option === "C" ? "success" : "danger") : undefined}
        >
           <span dangerouslySetInnerHTML={{ __html: option_c }} />
        </CustomRadio>
        <CustomRadio
          value="D"
          color={selected === "D" ? (correct_option === "D" ? "success" : "danger") : undefined}
        >
          <span dangerouslySetInnerHTML={{ __html: option_d }} />
        </CustomRadio>
      </CheckboxGroup>
      <p className={cn("text-default-500 text-small")}>Selected: {selected}</p>
    </div>
  );
}

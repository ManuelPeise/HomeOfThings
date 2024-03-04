import React from "react";

const PlayGround: React.FC = () => {
  const array = Array(1000).fill(999, 0);

  return (
    <div style={{ display: "flex", flexDirection: "column" }}>
      {array.map((item, index) => (
        <div>
          {item}-{index}
        </div>
      ))}
    </div>
  );
};

export default PlayGround;

import { useState } from 'react';

export default function State() {
  const [counter, setCounter] = useState(0);

  let name = '';

  console.log('State Render');
  console.log(name);

  const onClickHandler = () => {
    setCounter((c) => {
      return c + 1;
    });
    name = 'shdhs';
    console.log(name);
  };

  return (
    <div>
      <h2>You Clicked {counter} times</h2>
      <button onClick={onClickHandler}>Click Me</button>
    </div>
  );
}

// const onClickHandler = () => {
//   debugger
//   setCounter(counter + 1)
//   setCounter(counter + 1)
//   setCounter((c) => {
//       debugger
//       console.log(counter)
//       console.log(c)
//       return c + 1;
//   });
// };

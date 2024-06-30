import { ChangeEvent, useEffect, useState } from 'react';

export default function App() {
  const [option, setOption] = useState<string>('A');

  const onChangeHandler = (event: ChangeEvent<HTMLSelectElement>) => {
    setOption(event.target.value);
  };

  useEffect(() => {
    setTimeout(() => {
      alert(option);
    }, 2000);
  }, [option]);

  return (
    <select value={option} onChange={onChangeHandler}>
      <option value="A">A</option>
      <option value="B">B</option>
      <option value="C">C</option>
    </select>
  );
}

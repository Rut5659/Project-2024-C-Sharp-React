import { ChangeEvent, KeyboardEvent, useState } from 'react';

export default function Parent() {
  const [name, setName] = useState('');

  console.log('Parent Render');
  const onNameChange = (name: string) => {
    setName(name);
  };

  return (
    <>
      <Child onNameChange={onNameChange} />
      <DisplayName name={name} />
    </>
  );
}

type ChildProps = {
  onNameChange: (name: string) => void;
};

export function Child(props: ChildProps) {
  let name = '';
  console.log('Child Render');

  function onChangeHandler(event: ChangeEvent<HTMLInputElement>): void {
    name = event.target.value;
  }

  const handleKeyUp = (event: KeyboardEvent) => {
    if (event.key === 'Enter') {
      props.onNameChange(name);
    }
  };

  return <input onChange={onChangeHandler} onKeyUp={handleKeyUp} />;
}

type DisplayNameProps = {
  name: string;
};

export function DisplayName(props: DisplayNameProps) {
  console.log('DisplayName Render');

  return <h2>{props.name}</h2>;
}

// function onChangeHandler1(event: ChangeEvent<HTMLInputElement>) {
//     // console.log(event)
//     alert('hi')
// }

// function onChangeHandler2(number: number): ChangeEventHandler<HTMLInputElement> {
//     alert(number)
//     return (event: ChangeEvent<HTMLInputElement>) => {
//         console.log(number)
//         console.log(event)
//     }
// }

// return <input onChange={onChangeHandler1} />
// return <input onChange={onChangeHandler2(100)} />

import {Button, Input, Modal} from "@skbkontur/react-ui";
import {useState} from "react";

interface NameModalProps {
    name?: null | string;
    onChange: (v: string) => void;
}

export function NameModal({ name, onChange }: NameModalProps) {
    const [text, setText] = useState(name || "");
    return <Modal>
        <Modal.Header>Введите имя</Modal.Header>
        <Modal.Body>
            <Input value={text} onValueChange={v => setText(v)}/>
        </Modal.Body>
        <Modal.Footer>
            <Button use="primary" onClick={() => onChange(text)}>Сохранить</Button>
        </Modal.Footer>
    </Modal>
}
import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css'],
})
export class TextInputComponent implements ControlValueAccessor {
  @Input() label: string = '';
  @Input() type: string = 'text';

  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
  }

  writeValue(): void {
    // No-op for now
  }

  registerOnChange(): void {
    // No-op for now
  }

  registerOnTouched(): void {
    // No-op for now
  }

  get control(): FormControl {
    return this.ngControl.control as FormControl;
  }
}

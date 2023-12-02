import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, ElementRef, HostListener, ViewChild } from '@angular/core';

@Component({
  selector: 'app-searchbar',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './searchbar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SearchbarComponent {
  @ViewChild('myDialog') dialog!: ElementRef<HTMLDialogElement>;
  @ViewChild('dialogContainer') dialogContainer!: ElementRef<HTMLDivElement>
  private isDialogOpen: boolean = false;

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: Event): void {
    const targetNode = event.target as HTMLElement;

    if (this.isDialogOpen &&
      this.dialog.nativeElement.contains(targetNode) &&
      !this.dialogContainer.nativeElement.contains(targetNode)) {
      this.dialog.nativeElement.close();
    }
  }

  closeDialog() {
    this.isDialogOpen = false;
    this.dialog.nativeElement.close();
  }

  openDialog() {
    this.isDialogOpen = true;
    this.dialog.nativeElement.showModal();
  }
}